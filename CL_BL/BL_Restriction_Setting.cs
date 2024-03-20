using CL_BE;
using CL_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_BL
{
    public class BL_Restriction_Setting
    {
        public DataTable ListarConfiguracionRestriccion(string RestrictionTable, string Search, string QueryValue)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DA_Restriction_Setting().ListarConfiguracionRestriccion(RestrictionTable, Search, QueryValue);               
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable ListarConfiguracionRestriccionColumn(string RestrictionTable)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = new DA_Restriction_Setting().ListarConfiguracionRestriccionColumn(RestrictionTable);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public string CrearMapa(int IdUser, string Nombre, string TablaRestriccion, string RestriccionesSeleccionadas, string RestrictionColumns)
        {

            string resultado = "";

            try
            {
                string[] arrayRestrictionColumns = RestrictionColumns.Split(',');
                string[] arrayRestriccionesSeleccionadas = RestriccionesSeleccionadas.Split(',');
                string filaDatos = "";

                for (int i = 0; i < arrayRestrictionColumns.Length; i++)
                {
                    int valor = 0;

                    for (int x = 0; x < arrayRestriccionesSeleccionadas.Length; x++)
                    {
                        if (arrayRestrictionColumns[i].ToString().Trim().Equals(arrayRestriccionesSeleccionadas[x].ToString().Trim()))
                        {
                            valor = 1;
                            break;
                        }
                        else
                        {
                            valor = 0;
                        }
                    }

                    if (valor == 1)
                    {
                        filaDatos = filaDatos + "1,";
                    }
                    else
                    {
                        filaDatos = filaDatos + "0,";
                    }
                }

                string[] arrayFilaDatos = filaDatos.Split(',');

                string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 ";

                sql = sql + "BEGIN BEGIN TRANSACTION BEGIN TRY ";

                sql = sql + "IF NOT EXISTS(SELECT ValidationDescription FROM " + TablaRestriccion + " WHERE ValidationDescription = '" + Nombre + "' OR (";

                for (int i = 0; i < arrayRestrictionColumns.Length; i++)
                {
                    sql = sql + arrayRestrictionColumns[i].ToString() + " = " + arrayFilaDatos[i].ToString() + " AND ";
                }

                sql = sql.Substring(0, sql.Length - 4);
                sql = sql + " )) BEGIN INSERT INTO " + TablaRestriccion + " (RegistrationUser, ValidationDescription, ";

                for (int i = 0; i < arrayRestrictionColumns.Length; i++)
                {
                    sql = sql + arrayRestrictionColumns[i].ToString() + ", ";
                }

                sql = sql.Substring(0, sql.Length - 2);

                sql = sql + ") VALUES (" + IdUser + ",'" + Nombre + "', ";

                for (int i = 0; i < arrayFilaDatos.Length; i++)
                {
                    sql = sql + arrayFilaDatos[i].ToString() + ", ";
                }

                sql = sql.Substring(0, sql.Length - 4);

                string tableHistRestriction = "";
                string idHistoricRestriction = "";
                if (TablaRestriccion == "TB_VEHICLE_VALIDATION_MAP")
                {
                    tableHistRestriction = "TB_ZHIST_VEHICLE_VALIDATION_MAP";
                    idHistoricRestriction = "IdVehicleValidationMap";
                }
                else if (TablaRestriccion == "TB_OPERATOR_VALIDATION_MAP")
                {
                    tableHistRestriction = "TB_ZHIST_OPERATOR_VALIDATION_MAP";
                    idHistoricRestriction = "IdOperatorValidationMap";
                }
                else if (TablaRestriccion == "TB_DRIVER_VALIDATION_MAP")
                {
                    tableHistRestriction = "TB_ZHIST_DRIVER_VALIDATION_MAP";
                    idHistoricRestriction = "IdDriverValidationMap";
                }

                sql = sql + ") BEGIN IF (@@ROWCOUNT = 0) BEGIN SET @RESULT = '0' END ELSE BEGIN " + 
                        " INSERT INTO " + tableHistRestriction + " SELECT TOP 1 " + idHistoricRestriction + ", " +
                        " ValidationDescription, FlagType, RegistrationStatus, MigrationStatus, RegistrationUser, RegistrationDate, UpdateUser, UpdateDate, GetDate(), " + IdUser + ", 'C' " +
                        " FROM " + TablaRestriccion + " ORDER BY " + idHistoricRestriction + " DESC " +
                        " IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN SET @Result = 1 " +
                    " END END END END";

                sql = sql + " ELSE BEGIN SET @Result = '2' END ";

                sql = sql + " END TRY " +
				    " BEGIN CATCH " +
				    " ROLLBACK TRANSACTION " +
				    " DECLARE @ENumber INT " +
				    " SET @result=SUBSTRING(ERROR_MESSAGE(),1,300) " +
				    " SET @ENumber = ERROR_NUMBER() " +
				    " EXEC MSP_ERROR_CREATE " +
				    " @ErrorNumber = @ENumber, " +
				    " @ErrorMessage = @Result, " +
				    " @Comment = 'ERROR AL INSERTAR UNA RESTRICCION', " +
				    " @SpName = 'MSP_RESTRICTION_CREATE'," + 
                    " @RegistrationUser = " + IdUser +
				    " END CATCH " + 
				    " IF @@TRANCOUNT>0 " +
				    " BEGIN " +
				    " COMMIT TRANSACTION " +
				    " END " +
				    " SELECT @Result as 'Resultado' END" ;

                resultado = new DA_Restriction_Setting().CrearMapa(sql);                
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarMapa(int Id, int IdUser, string Nombre, string TablaRestriccion, string RestriccionesSeleccionadas, string RestrictionColumns)
        {

            string resultado = "";

            try
            {
                string[] arrayRestrictionColumns = RestrictionColumns.Split(',');
                string[] arrayRestriccionesSeleccionadas = RestriccionesSeleccionadas.Split(',');
                string filaDatos = "";
                for (int i = 0; i < arrayRestrictionColumns.Length; i++)
                {
                    int valor = 0;

                    for (int x = 0; x < arrayRestriccionesSeleccionadas.Length; x++)
                    {
                        if (arrayRestrictionColumns[i].ToString().Trim().Equals(arrayRestriccionesSeleccionadas[x].ToString().Trim()))
                        {
                            valor = 1;
                            break;
                        }
                        else
                        {
                            valor = 0;
                        }
                    }

                    if (valor == 1)
                    {
                        filaDatos = filaDatos + "1,";
                    }
                    else
                    {
                        filaDatos = filaDatos + "0,";
                    }
                }

                string idmapCampo = "";
                if (TablaRestriccion == "TB_VEHICLE_VALIDATION_MAP")
                {
                    idmapCampo = "IdVehicleValidationMap";
                }
                else if (TablaRestriccion == "TB_DRIVER_VALIDATION_MAP")
                {
                    idmapCampo = "IdDriverValidationMap";
                }
                else if (TablaRestriccion == "TB_OPERATOR_VALIDATION_MAP")
                {
                    idmapCampo = "IdOperatorValidationMap";
                }

                string[] arrayFilaDatos = filaDatos.Split(',');

                string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 " +
                    " BEGIN BEGIN TRANSACTION BEGIN TRY DECLARE @MapValidation INT ";

                sql = sql + " IF NOT EXISTS(SELECT 1 FROM " + TablaRestriccion + " WHERE RegistrationStatus = 'A' AND " + idmapCampo + "=" + Id + ") ";
                sql = sql + " BEGIN SET @MapValidation = 1 END ";
                sql = sql + " IF (@MapValidation = 1) BEGIN SET @Result = '3' END ELSE BEGIN ";
                sql = sql + " IF EXISTS (SELECT * FROM " + TablaRestriccion + " WHERE " + arrayRestrictionColumns[0].ToString() + "!= " + Id + " AND ";

                for (int i = 1; i < arrayRestrictionColumns.Length; i++)
                {
                    sql = sql + arrayRestrictionColumns[i].ToString() + " = " + arrayFilaDatos[i].ToString() + " AND ";
                }

                sql = sql.Substring(0, sql.Length - 4);
                sql = sql + " ) BEGIN SET @Result = 2 END "; 
                sql = sql + " ELSE BEGIN";
                sql = sql + " UPDATE " + TablaRestriccion + " SET RegistrationUser = " + IdUser + ", ValidationDescription = '" + Nombre + "', ";

                for (int i = 1; i < arrayRestrictionColumns.Length; i++)
                {
                    sql = sql + arrayRestrictionColumns[i].ToString() + " = " + arrayFilaDatos[i].ToString() + ", ";
                }

                sql = sql.Substring(0, sql.Length - 2);

                sql = sql + " WHERE " + arrayRestrictionColumns[0].ToString() + " = " + Id;

                string tableHistRestriction = "";
                if (TablaRestriccion == "TB_VEHICLE_VALIDATION_MAP")
	                tableHistRestriction = "TB_ZHIST_VEHICLE_VALIDATION_MAP";
                else if (TablaRestriccion == "TB_OPERATOR_VALIDATION_MAP")
                    tableHistRestriction = "TB_ZHIST_OPERATOR_VALIDATION_MAP";
                else if (TablaRestriccion == "TB_DRIVER_VALIDATION_MAP")
                    tableHistRestriction = "TB_ZHIST_DRIVER_VALIDATION_MAP";

                sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN " + 
                    " INSERT INTO " + tableHistRestriction + " SELECT " + arrayRestrictionColumns[0].ToString() + ", " +
                        " ValidationDescription, FlagType, RegistrationStatus, MigrationStatus, RegistrationUser, RegistrationDate, UpdateUser, UpdateDate, GetDate(), " + IdUser + ", 'A' " +
                        " FROM " + TablaRestriccion + " WHERE " + arrayRestrictionColumns[0].ToString() + " = " + Id +
                        " IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN SET @Result = 1 END " +
                        " END END END ";

                sql = sql + " END TRY " +
                    " BEGIN CATCH " +
                    " ROLLBACK TRANSACTION " +
                    " DECLARE @ENumber INT " +
                    " SET @result=SUBSTRING(ERROR_MESSAGE(),1,300) " +
                    " SET @ENumber = ERROR_NUMBER() " +
                    " EXEC MSP_ERROR_CREATE " +
                    " @ErrorNumber = @ENumber, " +
                    " @ErrorMessage = @Result, " +
                    " @Comment = 'ERROR AL INSERTAR UNA RESTRICCION', " +
                    " @SpName = 'MSP_RESTRICTION_CREATE'," +
                    " @RegistrationUser = " + IdUser +
                    " END CATCH " +
                    " IF @@TRANCOUNT>0 " +
                    " BEGIN " +
                    " COMMIT TRANSACTION " +
                    " END " +
                    " SELECT @Result as 'Resultado' END ";

                resultado = new DA_Restriction_Setting().EditarMapa(sql);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EditarEstadoRestriccionMapa(int Id, int IdUser, string TablaRestriccion)
        {
            string resultado = "";

            try
            {
                resultado = new DA_Restriction_Setting().EditarEstadoRestriccionMapa(Id, IdUser, TablaRestriccion);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string EliminarMapa(int Id, int IdUser, string TablaRestriccion)
        {
            var resultado = "";

            try
            {
                resultado = new DA_Restriction_Setting().EliminarMapa(Id, IdUser, TablaRestriccion);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string GrabarMapaVehiculo(string VehiculosSeleccionados, int IdMap, int IdUser, string ListaInicial)
        {

            string resultado = "";
            string[] arrayVehiculosSeleccionados = null;
            string[] arrayListaInicial = null;

            try
            {
                string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 ";
                sql = sql + "BEGIN BEGIN TRANSACTION BEGIN TRY ";

                if (VehiculosSeleccionados == "" && ListaInicial == "")
                {
                    sql = sql + "SET @Result = 3 ";                    
                }

                if (VehiculosSeleccionados != "" && ListaInicial == "")
                {
                    arrayVehiculosSeleccionados = VehiculosSeleccionados.Split(',');
                    //  VERIFICAR SI LOS VEHICULOS TIENEN MAPA 1 : SIN RESTRICCIONES
                    sql = sql + "DECLARE @CANT_VEH_SELEC INT SET @CANT_VEH_SELEC = (SELECT COUNT(*) FROM TB_VEHICLE WHERE IdVehicle IN (" + VehiculosSeleccionados + ") AND IdVehicleValidationMap = 1) ";
                    //  SI CANTIDAD DE VEHICULOS SELECCIONADOS ES IGUAL A LA CANTIDADA DE VEHICULOS CONSULTADOS
                    sql = sql + "IF (@CANT_VEH_SELEC = " + arrayVehiculosSeleccionados.Length + ") BEGIN ";
                    //  ACTUALIZO LOS VEHICULOS AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_VEHICLE SET IdVehicleValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdVehicle IN  (" + VehiculosSeleccionados + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN SET @Result = 1 END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (VehiculosSeleccionados == "" && ListaInicial != "")
                {
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS VEHICULOS TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_VEH_SELEC INT SET @CANT_VEH_SELEC = (SELECT COUNT(*) FROM TB_VEHICLE WHERE IdVehicle IN (" + ListaInicial + ") AND IdVehicleValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE VEHICULOS SELECCIONADOS ES IGUAL A LA CANTIDADA DE VEHICULOS CONSULTADOS
                    sql = sql + "IF (@CANT_VEH_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS VEHICULOS AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_VEHICLE SET IdVehicleValidationMap = 1, UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdVehicle IN (" + ListaInicial + ") AND IdVehicleValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN SET @Result = 1 END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (VehiculosSeleccionados != "" && ListaInicial != "")
                {
                    arrayVehiculosSeleccionados = VehiculosSeleccionados.Split(',');
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS VEHICULOS TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_VEH_SELEC INT SET @CANT_VEH_SELEC = (SELECT COUNT(*) FROM TB_VEHICLE WHERE IdVehicle IN (" + ListaInicial + ") AND IdVehicleValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE VEHICULOS SELECCIONADOS ES IGUAL A LA CANTIDADA DE VEHICULOS CONSULTADOS
                    sql = sql + "IF (@CANT_VEH_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS VEHICULOS AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_VEHICLE SET IdVehicleValidationMap = 1, UpdateUser = " + IdUser + ", UpdateDate = GETDATE()  WHERE IdVehicle IN (" + ListaInicial + ") AND IdVehicleValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN SET @Result = 1 ";
                    sql = sql + "UPDATE TB_VEHICLE SET IdVehicleValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdVehicle IN (" + VehiculosSeleccionados + ") END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                sql = sql + "END TRY BEGIN CATCH ROLLBACK TRANSACTION ";
                sql = sql + " DECLARE @ENumber INT " +
                        "SET @result=SUBSTRING(ERROR_MESSAGE(),1,300) " +
                        "SET @ENumber = ERROR_NUMBER() " +
                        "EXEC MSP_ERROR_CREATE " +
                        "@ErrorNumber = @ENumber, " +
                        "@ErrorMessage = @Result, " +
                        "@Comment = 'ERROR AL ACTUALIZAR UN MAPA DE VEHICULO', " +
                        "@SpName = 'QUERY ACTUALIZAR MAPA VEHICULO', " +
                        "@RegistrationUser = " + IdUser + " " +
                        "END CATCH " +
                        "IF @@TRANCOUNT > 0 " +
                        "BEGIN " +
                        "COMMIT TRANSACTION " +
                        "END " +
                        "SELECT @Result as 'Resultado' " +
                        "END" ;
                            
                resultado = new DA_Restriction_Setting().GrabarMapaVehiculo(sql);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string GrabarMapaOperador(string OperadoresSeleccionados, int IdMap, int IdUser, string ListaInicial)
        {

            string resultado = "";
            string[] arrayOperadorSeleccionados = null;
            string[] arrayListaInicial = null;

            try
            {
                string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 ";
                sql = sql + "BEGIN BEGIN TRANSACTION BEGIN TRY ";

                if (OperadoresSeleccionados == "" && ListaInicial == "")
                {
                    sql = sql + "SET @Result = 3 ";
                }

                if (OperadoresSeleccionados != "" && ListaInicial == "")
                {
                    arrayOperadorSeleccionados = OperadoresSeleccionados.Split(',');
                    //  VERIFICAR SI LOS OPERADORES TIENEN MAPA 1 : SIN RESTRICCIONES
                    sql = sql + "DECLARE @CANT_OPE_SELEC INT SET @CANT_OPE_SELEC = (SELECT COUNT(*) FROM TB_OPERATOR WHERE IdOperator IN (" + OperadoresSeleccionados + ") AND IdOperatorValidationMap = 1) ";
                    //  SI CANTIDAD DE OPERADORES SELECCIONADOS ES IGUAL A LA CANTIDADA DE OPERADORES CONSULTADOS
                    sql = sql + "IF (@CANT_OPE_SELEC = " + arrayOperadorSeleccionados.Length + ") BEGIN ";
                    //  ACTUALIZO LOS OPERADORES AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_OPERATOR SET IdOperatorValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdOperator IN  (" + OperadoresSeleccionados + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_OPERATOR SELECT  *, '01/01/2000',0,'A' FROM TB_OPERATOR WHERE IdOperator IN(" + OperadoresSeleccionados + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result=0 ROLLBACK TRANSACTION END ELSE BEGIN SET @Result = 1 END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (OperadoresSeleccionados == "" && ListaInicial != "")
                {
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS OPERADORES TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_OPE_SELEC INT SET @CANT_OPE_SELEC = (SELECT COUNT(*) FROM TB_OPERATOR WHERE IdOperator IN (" + ListaInicial + ") AND IdOperatorValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE OPERADORES SELECCIONADOS ES IGUAL A LA CANTIDADA DE OPERADORES CONSULTADOS
                    sql = sql + "IF (@CANT_OPE_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS OPERADORES AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_OPERATOR SET IdOperatorValidationMap = 1, UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdOperator IN (" + ListaInicial + ") AND IdOperatorValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_OPERATOR SELECT  *, '01/01/2000',0,'A' FROM TB_OPERATOR WHERE IdOperator IN(" + ListaInicial + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result=0 ROLLBACK TRANSACTION END ELSE BEGIN SET @Result = 1 END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (OperadoresSeleccionados != "" && ListaInicial != "")
                {
                    arrayOperadorSeleccionados = OperadoresSeleccionados.Split(',');
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS OPERADORES TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_OPE_SELEC INT SET @CANT_OPE_SELEC = (SELECT COUNT(*) FROM TB_OPERATOR WHERE IdOperator IN (" + ListaInicial + ") AND IdOperatorValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE OPERADORES SELECCIONADOS ES IGUAL A LA CANTIDADA DE OPERADORES CONSULTADOS
                    sql = sql + "IF (@CANT_OPE_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS OPERADORES AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_OPERATOR SET IdOperatorValidationMap = 1, UpdateUser = " + IdUser + ",UpdateDate = GETDATE()  WHERE IdOperator IN (" + ListaInicial + ") AND IdOperatorValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_OPERATOR SELECT  *, '01/01/2000',0,'A' FROM TB_OPERATOR WHERE IdOperator IN("+ ListaInicial+") ";
                    sql =  sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ELSE BEGIN ";
                    sql = sql + " UPDATE TB_OPERATOR SET IdOperatorValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdOperator IN (" + OperadoresSeleccionados + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ";
                    sql = sql + " ELSE BEGIN INSERT INTO TB_ZHIST_OPERATOR SELECT  *, '01/01/2000',0,'A' FROM TB_OPERATOR WHERE IdOperator IN(" + ListaInicial + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ";
                    sql = sql + " ELSE BEGIN SET @Result = 1 END END END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                sql = sql + "END TRY BEGIN CATCH ROLLBACK TRANSACTION ";
                sql = sql + " DECLARE @ENumber INT " +
                        "SET @result=SUBSTRING(ERROR_MESSAGE(),1,300) " +
                        "SET @ENumber = ERROR_NUMBER() " +
                        "EXEC MSP_ERROR_CREATE " +
                        "@ErrorNumber = @ENumber, " +
                        "@ErrorMessage = @Result, " +
                        "@Comment = 'ERROR AL ACTUALIZAR UN MAPA DE OPERADOR', " +
                        "@SpName = 'QUERY ACTUALIZAR MAPA OPERADOR', " +
                        "@RegistrationUser = " + IdUser + " " +
                        "END CATCH " +
                        "IF @@TRANCOUNT > 0 " +
                        "BEGIN " +
                        "COMMIT TRANSACTION " +
                        "END " +
                        "SELECT @Result as 'Resultado' " +
                        "END";

                resultado = new DA_Restriction_Setting().GrabarMapaVehiculo(sql);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public string GrabarMapaConductor(string ConductoresSeleccionados, int IdMap, int IdUser, string ListaInicial)
        {

            string resultado = "";
            string[] arrayConductorSeleccionados = null;
            string[] arrayListaInicial = null;

            try
            {
                string sql = "DECLARE @Result VARCHAR(500) SET @Result=0 ";
                sql = sql + "BEGIN BEGIN TRANSACTION BEGIN TRY ";

                if (ConductoresSeleccionados == "" && ListaInicial == "")
                {
                    sql = sql + "SET @Result = 3 ";
                }

                if (ConductoresSeleccionados != "" && ListaInicial == "")
                {
                    arrayConductorSeleccionados = ConductoresSeleccionados.Split(',');
                    //  VERIFICAR SI LOS CONDUCTORES TIENEN MAPA 1 : SIN RESTRICCIONES
                    sql = sql + "DECLARE @CANT_CON_SELEC INT SET @CANT_CON_SELEC = (SELECT COUNT(*) FROM TB_DRIVER WHERE IdDriver IN (" + ConductoresSeleccionados + ") AND IdDriverValidationMap = 1) ";
                    //  SI CANTIDAD DE CONDUCTORES SELECCIONADOS ES IGUAL A LA CANTIDADA DE CONDUCTORES CONSULTADOS
                    sql = sql + "IF (@CANT_CON_SELEC = " + arrayConductorSeleccionados.Length + ") BEGIN ";
                    //  ACTUALIZO LOS CONDUCTORES AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_DRIVER SET IdDriverValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdDriver IN  (" + ConductoresSeleccionados + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_DRIVER SELECT  *, '01/01/2000',0,'A' FROM TB_DRIVER WHERE IdDriver IN(" + ConductoresSeleccionados + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result=0 ROLLBACK TRANSACTION END ELSE BEGIN SET @Result = 1 END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (ConductoresSeleccionados == "" && ListaInicial != "")
                {
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS CONDUCTORES TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_CON_SELEC INT SET @CANT_CON_SELEC = (SELECT COUNT(*) FROM TB_DRIVER WHERE IdDriver IN (" + ListaInicial + ") AND IdDriverValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE CONDUCTORES SELECCIONADOS ES IGUAL A LA CANTIDADA DE CONDUCTORES CONSULTADOS
                    sql = sql + "IF (@CANT_CON_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS CONDUCTORES AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_DRIVER SET IdDriverValidationMap = 1, UpdateUser = " + IdUser + " WHERE IdDriver IN (" + ListaInicial + ") AND IdDriverValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_DRIVER SELECT  *, '01/01/2000',0,'A' FROM TB_DRIVER WHERE IdDriver IN(" + ListaInicial + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result=0 ROLLBACK TRANSACTION END ELSE BEGIN SET @Result = 1 END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                if (ConductoresSeleccionados != "" && ListaInicial != "")
                {
                    arrayConductorSeleccionados = ConductoresSeleccionados.Split(',');
                    arrayListaInicial = ListaInicial.Split(',');
                    //  VERIFICAR SI LOS VEHICULOS TIENEN MAPA 1 : 
                    sql = sql + "DECLARE @CANT_CON_SELEC INT SET @CANT_CON_SELEC = (SELECT COUNT(*) FROM TB_DRIVER WHERE IdDriver IN (" + ListaInicial + ") AND IdDriverValidationMap IN (1," + IdMap + ")) ";
                    //  SI CANTIDAD DE VEHICULOS SELECCIONADOS ES IGUAL A LA CANTIDADA DE VEHICULOS CONSULTADOS
                    sql = sql + "IF (@CANT_CON_SELEC = " + arrayListaInicial.Length + ") BEGIN ";
                    //  ACTUALIZO LOS VEHICULOS AL NUEVO MAPA ASIGNADO
                    sql = sql + "UPDATE TB_DRIVER SET IdDriverValidationMap = 1, UpdateUser = " + IdUser + ",UpdateDate = GETDATE()  WHERE IdDriver IN (" + ListaInicial + ") AND IdDriverValidationMap IN (1," + IdMap + ") ";
                    //  VERIFICO SI ES CORRECTA O INCORRECTA LA ACTUALIZACION
                    sql = sql + "IF (@@ROWCOUNT = 0) BEGIN SET @Result = 0 END ELSE BEGIN ";
                    sql = sql + " INSERT INTO TB_ZHIST_DRIVER SELECT  *, '01/01/2000',0,'A' FROM TB_DRIVER WHERE IdDriver IN(" + ListaInicial + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ELSE BEGIN ";
                    sql = sql + " UPDATE TB_DRIVER SET IdDriverValidationMap = " + IdMap + ", UpdateUser = " + IdUser + ", UpdateDate = GETDATE() WHERE IdDriver IN (" + ConductoresSeleccionados + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ";
                    sql = sql + " ELSE BEGIN INSERT INTO TB_ZHIST_DRIVER SELECT  *, '01/01/2000',0,'A' FROM TB_DRIVER WHERE IdDriver IN(" + ListaInicial + ") ";
                    sql = sql + " IF(@@ROWCOUNT = 0) BEGIN SET @Result='0' ROLLBACK TRANSACTION END ";
                    sql = sql + " ELSE BEGIN SET @Result = 1 END END END END END ";
                    sql = sql + "ELSE BEGIN SET @Result = 2 END ";
                }

                sql = sql + "END TRY BEGIN CATCH ROLLBACK TRANSACTION ";
                sql = sql + " DECLARE @ENumber INT " +
                        "SET @result=SUBSTRING(ERROR_MESSAGE(),1,300) " +
                        "SET @ENumber = ERROR_NUMBER() " +
                        "EXEC MSP_ERROR_CREATE " +
                        "@ErrorNumber = @ENumber, " +
                        "@ErrorMessage = @Result, " +
                        "@Comment = 'ERROR AL ACTUALIZAR UN MAPA DE OPERADOR', " +
                        "@SpName = 'QUERY ACTUALIZAR MAPA OPERADOR', " +
                        "@RegistrationUser = " + IdUser + " " +
                        "END CATCH " +
                        "IF @@TRANCOUNT > 0 " +
                        "BEGIN " +
                        "COMMIT TRANSACTION " +
                        "END " +
                        "SELECT @Result as 'Resultado' " +
                        "END";

                resultado = new DA_Restriction_Setting().GrabarMapaVehiculo(sql);
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }

        public List<BE_Restriction> ValidarRelacionRestriccionMapa(int IdValidationMap, string RestrictionTable)
        {
            
            var listaResultado = new List<BE_Restriction>();
            try
            {
                listaResultado = new DA_Restriction_Setting().ValidarRelacionRestriccionMapa(IdValidationMap, RestrictionTable);
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
                BE_Restriction bE_Restriction = new BE_Restriction();
                bE_Restriction.ValorConsulta = "0";
                bE_Restriction.MensajeConsulta = ex.Message;
                listaResultado.Add(bE_Restriction);
            }
            return listaResultado;

        }
    }
}
