using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using System.Configuration;

namespace CapaDatos
{
    public class DatosSQL : Datos
    {
        //--------------------------------------
        //-------atributos
        //------------------------
        static Hashtable ColComandos = new Hashtable();
        //-------------------------------------------------
        //----metodos
        //--------------------------------------------------
        //---------------------------constructores------------------

        // Cadena de Conexion extraida del Archivo de Configuracion de la Capa de Presentacion  
        private static string Cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        public DatosSQL()
        {
        }

        public DatosSQL(string CadenaConexion)
        {
            this.CadenaConexion = CadenaConexion;
        }

        public DatosSQL(string Servidor, string Base)
        {
            this.Base = Base;
            this.Servidor = Servidor;
        }

        //----------------otros metodos-------------

        public override string CadenaConexion
        {
            get
            { return Cadena; }
            set
            { this.aCadenaConexion = value; }
        }

        protected override void CargarParametros(IDbCommand oComando, Object[] Args)
        {
            int Limite = oComando.Parameters.Count;
            for (int i = 1; i < oComando.Parameters.Count; i++)
            {
                SqlParameter P = (SqlParameter)oComando.Parameters[i];
                if (i <= Args.Length)
                    P.Value = Args[i - 1];
                else
                    P.Value = null;
            }
        }

        protected override IDbCommand Comando(string ProcedimientoAlmacenado)
        {
            SqlCommand oComando;
            if (ColComandos.Contains(ProcedimientoAlmacenado))
                oComando = (SqlCommand)ColComandos[ProcedimientoAlmacenado];
            else
            {
                SqlConnection oConexion = new SqlConnection(this.CadenaConexion);
                oConexion.Open();
                oComando = new SqlCommand(ProcedimientoAlmacenado, oConexion);
                oComando.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(oComando);
                oConexion.Close();
                oConexion.Dispose();
                ColComandos.Add(ProcedimientoAlmacenado, oComando);
            }
            oComando.Connection = (SqlConnection)this.conexion;
            //oComando.transaction = (sqlTransaction) this .mTransaccion;
            return (IDbCommand)oComando;
        }

        protected override IDbCommand Comando_Consulta(string Consulta)
        {
            SqlCommand oComando;
            if (ColComandos.Contains(Consulta))
                oComando = (SqlCommand)ColComandos[Consulta];
            else
            {
                SqlConnection oConexion = new SqlConnection(this.CadenaConexion);
                oConexion.Open();
                oComando = new SqlCommand(Consulta, oConexion);
                oComando.CommandType = CommandType.Text;
                //SqlCommandBuilder.DeriveParameters(oComando);
                oConexion.Close();
                oConexion.Dispose();
                ColComandos.Add(Consulta, oComando);
            }
            oComando.Connection = (SqlConnection)this.conexion;
            //oComando.transaction = (sqlTransaction) this .mTransaccion;
            return (IDbCommand)oComando;
        }

        protected override IDbConnection CrearConexion(String CadenaConexion)
        {
            return (IDbConnection)new SqlConnection(CadenaConexion);
        }

        protected override IDataAdapter CrearDataAdapter(string ProcedimientoAlmacenado, params Object[] Args)
        {
            SqlDataAdapter oAdapter = new
                SqlDataAdapter((SqlCommand)Comando(ProcedimientoAlmacenado));
            if (Args.Length != 0)
                CargarParametros(oAdapter.SelectCommand, Args);
            return (IDataAdapter)oAdapter;
        }

        protected override IDataAdapter CrearDataAdapter_Consulta(string Consulta, params Object[] Args)
        {
            SqlDataAdapter oAdapter = new
                SqlDataAdapter((SqlCommand)Comando_Consulta(Consulta));
            if (Args.Length != 0)
                CargarParametros(oAdapter.SelectCommand, Args);
            return (IDataAdapter)oAdapter;
        }
    }
}

