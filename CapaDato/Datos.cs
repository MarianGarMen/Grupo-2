using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public abstract class Datos
    {
        //----------------------------------------------------
        //------------atributos
        //-------------------------------------------------
        //----nombre del servidor
        protected string aServidor = string.Empty;
        //----nombre de la base de datos
        protected string aBase = string.Empty;
        //---cadena de conexion completa
        protected string aCadenaConexion = string.Empty;

        //---interfaz,  que permite el  objeto de conexion desde la clase base 
        protected System.Data.IDbConnection aConexion;

        //----------------------------
        //---metodos
        //-------------------------------------------

        //-----------------------constructores-------------------
        public Datos()
        {

        }

        //--------------------propiedades------------------
        public string Servidor
        {
            get { return aServidor; }
            set { aServidor = value; }
        }

        public string Base
        {
            get { return aBase; }
            set { aBase = value; }
        }

        public abstract string CadenaConexion
        {
            get; set;
        }

        //---crea y obtiene un objeto para conectarse a la base de datos.
        protected System.Data.IDbConnection conexion
        {
            get
            {
                if (null == aConexion)
                {
                    aConexion = CrearConexion(this.CadenaConexion);
                }
                if (aConexion.State != System.Data.ConnectionState.Open)
                    aConexion.Open();
                return aConexion;
            }
        }

        /// <summary>
        /// Obtiene un DataSet a partir de una consulta.
        /// </summary>
        /// <param name="Consulta">Cadena de consulta</param>
        /// <returns>DataSet</returns>
        public System.Data.DataSet TraerDataSet_Consulta(String Consulta)
        {
            System.Data.DataSet mDataSet = new System.Data.DataSet();
            this.CrearDataAdapter_Consulta(Consulta).Fill(mDataSet);
            return mDataSet;
        }


        /// <summary>
        /// Obtiene un DataSet a partir de un procedimiento almacenado.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <returns>DataSet</returns>
        public System.Data.DataSet TraerDataSet(String ProcedimientoAlmacenado)
        {
            System.Data.DataSet mDataSet = new System.Data.DataSet();
            this.CrearDataAdapter(ProcedimientoAlmacenado).Fill(mDataSet);
            return mDataSet;
        }

        /// <summary>
        /// Obtiene un Dataset a partir de un procedimiento almacenado y sus parametros.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <param name="Parametros">Parametros</param>
        /// <returns>DataSet</returns>
        public System.Data.DataSet TraerDataSet(String ProcedimientoAlmacenado, params System.Object[] Parametros)
        {
            System.Data.DataSet mDataSet = new System.Data.DataSet();
            this.CrearDataAdapter(ProcedimientoAlmacenado, Parametros).Fill(mDataSet);
            return mDataSet;
        }

        /// <summary>
        /// Obiene un DataTable a partir de una consulta.
        /// </summary>
        /// <param name="Consulta">Consulta</param>
        /// <returns></returns>
        public System.Data.DataTable TraerDataTable_Consulta(String Consulta)
        {
            return TraerDataSet_Consulta(Consulta).Tables[0].Copy();
        }

        /// <summary>
        /// Obiene un DataTable a partir de un procedimiento almacenado.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <returns></returns>
        public System.Data.DataTable TraerDataTable(String ProcedimientoAlmacenado)
        {
            return TraerDataSet(ProcedimientoAlmacenado).Tables[0].Copy();
        }

        /// <summary>
        /// Obtiene un DataTable a partir de un procedimiento almacenado y sus parametros.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <param name="Parametros">Parametros</param>
        /// <returns>DataTable</returns>
        /// 
        public System.Data.DataTable TraerDataTable(String ProcedimientoAlmacenado, params System.Object[] Parametros)
        {
            return TraerDataSet(ProcedimientoAlmacenado, Parametros).Tables[0].Copy();
        }

        /// <summary>
        /// Obtiene un DataRow a partir de un procedimiento almacenado
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <returns>DataRow</returns>
        public System.Data.DataRow TraerDataRow(String ProcedimientoAlmacenado)
        {
            return TraerDataSet(ProcedimientoAlmacenado).Tables[0].Rows[0];
        }

        /// <summary>
        /// Obtiene un DataRow a partir de un procedimiento almacenado y sus parametros
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <param name="Parametros">Parametros</param>
        /// <returns>DataRow</returns>
        public System.Data.DataRow TraerDataRow(String ProcedimientoAlmacenado, params System.Object[] Parametros)
        {
            return TraerDataSet(ProcedimientoAlmacenado, Parametros).Tables[0].Rows[0];
        }

        /// <summary>
        /// Obtiene un valor a partir de un procedimiento almacenado.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <returns>Valor Escalar de tipo String</returns>
        public System.String TraerValor(String ProcedimientoAlmacenado)
        {
            return TraerDataSet(ProcedimientoAlmacenado).Tables[0].Rows[0][0].ToString();
        }

        /// <summary>
        /// obtiene un valor a partir de un procedimiento almacenado y sus parametros
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <param name="Parametros">Parametros</param>
        /// <returns>valor Escalar de tipo String</returns>
        public System.String TraerValor(String ProcedimientoAlmacenado, params System.Object[] Parametros)
        {
            return TraerDataSet(ProcedimientoAlmacenado, Parametros).Tables[0].Rows[0][0].ToString();
        }


        //-----------------------metodos abstractos------------------------
        protected abstract System.Data.IDbConnection CrearConexion(string Cadena);
        protected abstract System.Data.IDbCommand Comando(string ProcedimientoAlmacenado);
        protected abstract System.Data.IDataAdapter CrearDataAdapter(string ProcedimientoAlmacenado, params System.Object[] Parametros);
        protected abstract void CargarParametros(System.Data.IDbCommand Comando, System.Object[] Parametros);

        protected abstract System.Data.IDbCommand Comando_Consulta(string Consulta);
        protected abstract System.Data.IDataAdapter CrearDataAdapter_Consulta(string Consulta, params System.Object[] Parametros);

        //-----------------------mas metodos 1-----------------------
        /// <summary>
        /// Ejecuta un procedimiento almacenado en la base de datos.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <returns>Nro de instrucciones realizadas</returns>
        public int Ejecutar(string ProcedimientoAlmacenado)
        {
            return Comando(ProcedimientoAlmacenado).ExecuteNonQuery();
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado en la base de datos,utilizando los parametros.
        /// </summary>
        /// <param name="ProcedimientoAlmacenado">Procedimiento Almacenado</param>
        /// <param name="Parametros">Parametros</param>
        /// <returns>Nro de instrucciones realizadas</returns>
        public int Ejecutar(string ProcedimientoAlmacenado, params System.Object[] Parametros)
        {
            System.Data.IDbCommand Com = Comando(ProcedimientoAlmacenado);
            CargarParametros(Com, Parametros);
            int Resp = Com.ExecuteNonQuery();
            for (int i = 0; i < Com.Parameters.Count; i++)
            {
                System.Data.IDbDataParameter Par =
                    (System.Data.IDbDataParameter)Com.Parameters[i];
                if (Par.Direction == System.Data.ParameterDirection.InputOutput ||
            Par.Direction == System.Data.ParameterDirection.Output)
                    Parametros.SetValue(Par.Value, i);
            }
            return Resp;
        }

        //------------------------- mas atributos----------------

        protected System.Data.IDbTransaction mTransaccion;
        protected bool EnTranssaccion = false;

        //--------------------mas metodos 2----------------------------

        /// <summary>
        /// Comienza un transaccion en la base en uso.
        /// </summary>
        public void IniciarTransaccion()
        {
            mTransaccion = this.conexion.BeginTransaction();
            EnTranssaccion = true;
        }
        /// <summary>
        /// Confirma la transaccion activa.
        /// </summary>
        public void TerminarTransaccion()
        {
            try
            {
                mTransaccion.Commit();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                mTransaccion = null;
                EnTranssaccion = false;
            }
        }

        /// <summary>
        /// Aborta la transaccion activa.
        /// </summary>
        public void AbortarTransaccion()
        {
            try
            {
                mTransaccion.Rollback();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                mTransaccion = null;
                EnTranssaccion = false;
            }
        }
    }
}
