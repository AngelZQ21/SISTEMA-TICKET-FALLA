
//VALOR DE AÑOS A LISTAR EN LOS NUEVOS REPORTES

var aniosListar = 2;
var rangoFechaDias = 60;

/*------------------------------------------------------------------------------------Paginacion de grilla kendo*/
var PaginationKendoGrid = 10;
var CantidadDecimalesGraficas = 1;
var CantidadDecimalesListados = 1;
var PrecioDecimalesReportes = 2;
var TamanoDonaCircunferencia = 45;
var TamanoDonaAgujero = 30;
var PaginationKendoGrid = 10;
var tRutaServidor = "..";

/*-------------------------------------------------------------------------------------LIMITES DE INFORMACION EN GRAFICAS*/
var LimiteInformacionMostradaGrafica = 20;
var LimiteSeleccionItemsDualListBox = 20;

/*------------------------------------------------------------------------------------ MENSAJES CONFIRMACION*/
var CantidadRegistrosExportar = 12000;
var DefaultPassword = "123456";

var tTituloConfirmacion = '¿Estás seguro?';
var tTituloConfirmacionExportarExcel = 'Descarga de archivo';
var tMensajeConfirmacion = '¿Seguro que desea eliminar el registro? Tener en cuenta que no se podrán recuperar los datos.';
var tMensajeConfirmacionB = '¿Seguro que desea eliminar el registro?';
var tMensajeConfirmacionPassword = 'Se asignará la siguiente clave por defecto: 123456';

var tMensajeConfirmacionExportarExcel = 'Es probable que no pueda exportar la información por la capacidad de su memoria. ¿Seguro que desea continuar?';
var tColorBoton = '#DD6B55';
var tNombreBotonSi = 'SI';
var tNombreBotonNo = 'NO';
var tTituloExportarExcel = 'Se ha iniciado la descarga';
var tMensajeExportarExcel = 'Se esta ejecutando el proceso de descarga en segundo plano.';
var tMensajeConfirmacionAprobar = '¿Seguro de APROBAR las transacciones seleccionadas? Recuerda que este proceso impacta en los reportes de "Consumo".';
var tMensajeConfirmacionRechazar = '¿Seguro de RECHAZAR las transacciones seleccionadas?';
var tMensajeConfirmacionAnular = '¿Seguro de ANULAR la transacción seleccionada?';
var tMensajeValidacionDualListBox = 'Solo se pueden seleccionar como máximo ' + LimiteSeleccionItemsDualListBox + ' parámetros de consulta.';
var tMensajeConfirmacionEdicionComentario = '¿Seguro que desea actualizar el comentario? Tener en cuenta que se sobreescribiran los datos y/o el archivo adjunto.';
var tMensajeConfirmacionEliminarComentario = '¿Seguro que desea eliminar el comentario? Tener en cuenta que no se podrán recuperar los datos.'

/*------------------------------------------------------------------------------------ Mensaje validaciones*/
var tValoresVacios = 'Todos los campos obligatorios deben ser llenados';
/*ALERTA*/
var tTituloAlerta = '¡Alerta!';
/*EXITO*/
var tTituloExito = '¡Éxito!';
var tMensajeCreadoExito = 'Registro creado correctamente.';
var tIndicadorAtendido = 'Indicador atendido correctamente.';
var tMensajeActualizadoExito = 'Registro actualizado correctamente.';
var tMensajeCanceladoExito = 'Registro actualizado correctamente.';
var tMensajeEliminadoExito = 'Registro eliminado correctamente.';
/*ERROR*/
var tTituloError = '¡Error!';
var tMensajeErrorYaExiste = 'El registro ingresado ya existe. Favor de actualizar la página y volver a intentarlo.';
var tMensajeErrorNoExiste = 'El registro seleccionado no existe o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeErrorRegistroNoInactivo = 'El registro debe estar en estado "INACTIVO" para ser dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeErrorRegistroNoAnulado = 'El registro debe estar en estado "ANULADO" para ser dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeErrorDesconocido = 'No se pudo realizar el proceso. Verifique los datos y vuelva a intentarlo.';
var tMensajeErrorYaExisteEliminado = 'No se pudo realizar el proceso. El registro ya existe y se encuentra eliminado.';
var tMensajeErrorActualizar = 'No se pudo actualizar el registro.';
var tMensajeErrorCompletarCampos = 'Debe completar todos los campos.';
var tMensajeErrorClaveIgual = 'Las claves ingresadas no coinciden.';
var tMensajeClaveIncorrecta = 'Las clave actual ingresada no es correcta.';
var tMensajeErrorConfMenuPerfil = 'La vista principal seleccionada no está contemplada en las vistas activas. Verifique los datos y vuelva a intentarlo.'
var tErrorTipoValidacionListaNegra = 'No se pudo conseguir el tipo de validación';
var tValidacionListaNegraVacio = 'Debe ingresar un código válido. De ser el caso debe ir al módulo respectivo y actualizar los datos.'
var tMensajeErrorNoEsUltimoPeriodo = 'Solo se pueden eliminar los últimos periodos de cada producto.';
var tMensajeLogError = 'Error Capturado: ';
var tMensajeErrorTipoVehiculoMarca = 'No se puede crear un Modelo del Tipo Vehículo "SIN TIPO VEHÍCULO" ó de la Marca "SIN MARCA".';
var tMensajePersonaOperadorBloqueada = 'La persona asignada a este operador se encuentra bloqueda. Favor de ir a la Vista Gestor -> Gestión -> Persona';
var tMensajePersonaConductorBloqueada = 'La persona asignada a este conductor se encuentra bloqueda. Favor de ir a la Vista Gestor -> Gestión -> Persona';
var tMensajePersonaUsuarioBloqueada = 'La persona asignada a este usuario se encuentra bloqueda. Favor de ir a la Vista Gestor -> Gestión -> Persona';
var tMensajeErrorCCSinArea = 'No se puede crear un Centro de Costo del valor "Sin Área".'
var tValidacionPlacaCodigo = 'Debe ingresar una placa distinta al código.'
var tValidacionVehiculoEliminado = 'La placa ingresada ha sido eliminada. Si desea restaurar el equipo contacte al administrador del sistema.';

//CONTRATO
var tValidacionContratoAnulado = 'El contrato del vehículo se encuentra anulado. Favor de asignar un nuevo contrato para poder habilitar el vehículo.';
var tValidacionFechaInicioMayorFechaFin = 'La fecha de inicio ingresada es mayor a la fecha final.';
var tValidacionContratoCompania = 'Debe asignar un contrato a la compañia seleccionada. Para compañías terceras, no se permite asignar el valor "Sin Contrato".';
var tValidacionListaComboContratoError = 'No se pueden listar los contratos.';
var tValidacionListaComboContratoVacio = 'No existen contratos a listar.';
var tValidacionSeleccionarComboContrato = 'Debe seleccionar un Contrato para la Compañia seleccionada. De no existir, debe crearlo.';
var tValidacionContratoOperacion = 'No se puede asignar un contrato a la misma operación.';
var tValidacionComboContratoCompania = 'Debe seleccionar un Contrato para la Compañia seleccionada. De no existir, debe crearlo.';
var tValidacionContratoInactivo = 'El contrato Seleccionado se encuentra anulado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeConfirmacionRenovarContrato = 'Recuerda que si renuevas el contrato, afectará a los vencimientos de los vehículos seleccionados. Es importante tomar en cuenta que las fechas de un contrato solo se pueden ampliar más no reducir.';
var tMensajeConfirmacionAnularContrato = '¿Seguro que desea anular el Contrato? Este proceso no puede ser revertido.';
var tDiferenciaFechasRenovarContrato = 'La fecha de renovación debe ser mayor a la original.';
var tMensajeConfirmacionContrato = '¿Seguro que desea eliminar el registro? Tener en cuenta que este proceso no puede ser revertido.'



/*CONEXION*/
var tTituloErrorConexion = '¡Error de Conexión!';
var tMensajeErrorConexion = 'Error de conexión. Favor de actualizar la página e intentar nuevamente. <br> Si el error persiste, contacte al administrador del sistema.';
var tTiempoConexion = '8000';


//ASOCIACIÓN FLOTA- VEHÍCULO
var tValidacionFlotaVehiculoInactivo = 'La Asociación de Flota - Vehículo Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';

//FLOTA
var tValidacionFlotaInactivo = 'La Flota Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tValidacionListaComboFlotaVacio = 'No existen flotas a listar.';
var tValidacionListaComboFlotaError = 'No se pueden listar las flotas.';

//AÑO
var tValidacionListaComboAnoVacio = 'No existen Años a listar.';
var tValidacionListaComboAnoError = 'No se pueden los Años.';
//FORMULA
var tValidacionFormulaInactivo = 'La Formula Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';


//ESTACIÓN 
var tValidacionSeleccionarTipoEstacion = "Debe seleccionar un tipo de estación.";

//VEHICULO
var tValidacionPlaca = 'La placa ingresada ya existe';
var tValidacionFechaContratoRango = 'La fechas de vigencia del VehÍculo no están dentro del rango del Contrato.';
var tValidacionFechaOrdenServicioRango = 'La fechas de vigencia del VehÍculo no están dentro del rango de la Orden de Servicio.';
var tValidacionCantAbastecimiento = 'El año de producción o la cantidad de abastecimientos no son los correctos.';
var tValidacionSeleccionarComboVehiculo = 'Debe seleccionar una Placa. De no existir, debe crearla.';
var tValidacionSeleccionarComboVehiculoB = 'Debe seleccionar mínimo un Vehículo.';
var tValidacionListaComboVehiculoError = 'No se pueden listar vehículos.';
var tValidacionListaComboVehiculo = 'No existen o no se pueden listar vehículos.';
var tValidacionListaComboVehiculoVacio = 'No existen Vehículos a listar.';
var tValidacionVehiculoNoExiste = 'El Vehículo seleccionado no existe, ha sido bloqueado o eliminado.'
var tValidacionVehiculoInactivo = 'El Vehículo Seleccionado se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tMValidacionBuscarDatosVehiculo = 'Error en validación de datos. Favor contacte con el administrador de sistema.';
var tValidacionVehiculoVencido = 'Se ha superado la fecha de expiración actual del vehículo. Favor de actualizar la fecha del vehículo o de ser caso, renovar el contrato.'
var tValidacionFechasVehiculoPropio = 'No se pueden asignar fechas a Vehículos Propios.';
var tValidacionPatrocinadorVehiculoPropio = 'No se puede seleccionar un Patrocinador para vehículos propios';
var tValidacionContratoVehiculoPropio = 'No se puede asginar Contratos a vehículos propios';
var tValidacionContrataVehiculoPropio = 'No se puede seleccionar una Compañía Tercera para Vehículos Propios';
var tValidacionContratoServicio = 'Debe seleccionar un Contrato. De no existir, debe crearlo.';
var tValidacionFechasVehiculo = 'Debe ingresar las fechas de vigencia del Vehículo';
var tValidacionFechasVehiculoTercero = 'Debe ingresar fechas de vigencia a Vehículos Terceros.';
var tValidacionVehiculoEliminadoONoexiste = 'El Vehículo Seleccionado no existe o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tValidacionVehiculoAsociadoFlota = 'El Vehículo Seleccionado se encuentra asociado a otra Flota. Favor de actualizar la página y volver a intentarlo.';

//TIPO ABASTECIMIENTO
var tValidacionSeleccionarComboTipoAbastecimiento = 'Debe seleccionar al menos un tipo de abastecimiento.';


//COMPANIA
var tValidacionRuc = 'Debe ingresar un número de RUC válido.';
var tValidacionCorreo = 'Formato de Correo incorrecto.';
var tValidacionListaComboCompaniaError = 'No se pueden listar las compañías.';
var tValidacionListaComboPatrocinadorError = 'No se pueden listar los patrocinadores.';
var tValidacionListaComboCompaniaVacio = 'No existen compañías a listar.';
var tValidacionListaComboPatrocinadorVacio = 'No existen patrocinadores a listar.';
var tValidacionSeleccionarComboCompania = 'Debe seleccionar una Compañía. De no existir, debe crearla.';
var tValidacionSeleccionarComboPatrocinador = 'Debe seleccionar un Patrocinador. De no existir, debe crearlo.';
var tMantCorrectivoCompania = 'La Compañía y/o el contrato seleccionado han sido deshabilitados. Favor de verificar los datos y volver a intentar.';
var tValidacionCompaniaInactivo = 'La Compañía Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeConfirmacionCompania = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todos los CONTRATOS Y ORDENES DE SERVICIO ANULADOS relacionados a esta compañía y no se podrán recuperar.';

var tValidacionFechaInicioMayorFechaFin = 'La fecha de inicio ingresada es mayor a la fecha final.'
//AREA
var tValidacionListaComboAreaError = 'No se pueden listar las áreas.';
var tValidacionSeleccionarComboArea = 'Debe seleccionar un Área. De no existir, debe crearla.';
var tValidacionListaComboAreaVacio = 'No existen áreas a listar';
var tValidacionRelacionArea = 'Existen asociaciones de Área y C.Costo asociados a esta Área . Favor de inhabilitar primero las relaciones de Área y C.Costo. ';
var tValidacionAreaInactivo = 'El Área Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeConfirmacionArea = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todas las ASOCIACIONES DE ÁREA y C.COSTO INACTIVAS relacionados a esta Área y no se podrán recuperar.'


//ÁREA Y CENTRO DE COSTO
var tValidacionAreaCCInactivo = 'La Asociación de Área y Centro de Costo Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';


//CENTRO DE COSTO
var tValidacionListaComboCentroCostoError = 'No se pueden listar los centros de costo.';
var tValidacionListaComboCentroCostoVacio = 'No existen centros de costo a listar.';
var tValidacionSeleccionarComboCentroCosto = 'Debe seleccionar un Centro de Costo. De no existir, debe crearlo.';
var tValidacionRelacionCC = 'Existen asociaciones de Área y C.Costo asociados a este Centro de Costo . Favor de inhabilitar primero las relaciones de Área y C.Costo. ';
var tValidacionCCInactivo = 'El Centro de Costo Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.'
var tMensajeConfirmacionCC = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todas las ASOCIACIONES DE ÁREA y C.COSTO INACTIVAS relacionados a este Centro de Costo y no se podrán recuperar.'

//TIPO VEHICULO
var tValidacionListaComboTiposVehiculoError = 'No se pueden listar los tipos de vehículos';
var tValidacionListaComboTiposVehiculoVacio = 'No existen tipos de vehículos a listar';
var tValidacionSeleccionarComboTiposVehiculo = 'Debe seleccionar un Tipo de Vehículo. De no existir, debe crearlo.';
var tValidacionTipoVehiculoInactivo = 'El Tipo Vehículo Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tValidacionRelacionTipoVehiculo = 'Existen modelos asociados a este Tipo de Vehículo . Favor de inhabilitar primero el modelo. ';
var tMensajeConfirmacionTipoVehiculo = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todos los MODELOS INACTIVOS relacionados a este Tipo de Vehículo y no se podrán recuperar.'
//MARCA
var tValidacionListaComboMarcaError = 'No se pueden listar las marcas.';
var tValidacionListaComboMarcaVacio = 'No existen marcas a listar.';
var tValidacionSeleccionarComboMarca = 'Debe seleccionar una Marca. De no existir, debe crearla.';
var tValidacionMarcaInactivo = 'La Marca Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tValidacionRelacionMarca = 'Existen modelos asociados a esta Marca . Favor de inhabilitar primero el modelo. ';
var tMensajeConfirmacionMarca = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todos los MODELOS INACTIVOS relacionados a esta Marca y no se podrán recuperar.'
//MODELO
var tValidacionListaComboTiposRendimientoError = 'No se pueden listar los tipos de rendimiento.';
var tValidacionListaComboTiposRendimientoVacio = 'No existen tipos de rendimiento a listar.';
var tValidacionListaComboFlotaError = 'No se pueden listar las flotas.';
var tValidacionListaComboFlotaVacio = 'No existen flotas a listar.';
var tValidacionListaComboModeloError = 'No se pueden listar los modelos.';
var tValidacionListaComboModeloVacio = 'No existen modelos a listar.';
var tValidacionListaComboModeloVacioRelacion = 'No existen modelos relacionados a la Marca y Tipo de Vehículo seleccionado.';
var tValidacionSeleccionarComboTiposRendimiento = 'Debe seleccionar un Tipo de Rendimiento. De no existir, debe crearlo.';
var tValidacionSeleccionarComboFlota = 'Debe seleccionar una Flota. De no existir, debe crearla.';
var tValidacionSeleccionarComboModelo = 'Debe seleccionar un Modelo. De no existir, debe crearlo.';
var tValidacionModeloInactivo = 'El Modelo Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.'
//PERSONA
var tValidacionFechaNacimiento = 'Edad mínima requerida para un registro - 18 años.';
var tValidacionListaComboPersona = 'No existen o no se pueden listar personas.';
var tValidacionListaComboCargo = 'No existen o no se pueden listar los roles.';
var tValidacionListaComboDocumentos = 'No existen o no se pueden listar documentos.';
var tValidacionPersonaInactivo = 'El responsable Seleccionado o el rol perteneciente a ese responsable se encuentra inhabilitado. Favor de actualizar la página y volver a intentarlo.'
var tValidacionPersonaRolVehiculo = 'Existen vehículos asignados a este responsable con este rol. Para actualizar el rol, debe asignar el o los vehículos a un nuevo responsable.'
var tValidacionPersonaInactivoB = 'La Persona Seleccionada se encuentra inhabilitada o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.'
var tValidacionPersonaInactivoC = 'El rol del responsable seleccionado en el campo "Autoriza" ha sido modificado. Favor de verificar los datos, actualizar la página y volver a intentarlo.'
var tMensajeConfirmacionPersona = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todas las ASOCIACIONES USUARIO INACTIVOS relacionados a esta Persona y no se podrán recuperar.'
//CONDUCTOR
var tValidacionListaComboConductor = 'No existen o no se pueden listar conductores.';
var tValidacionConductorNoExiste = 'El Conductor seleccionado no existe, ha sido bloqueado o eliminado.';
var tMantCorrectivoConductor = 'El Conductor seleccionado ha sido deshabilitado. Favor de verificar los datos y volver a intentar.'
var tValidacionSeleccionarConductor = 'Debe seleccionar un Conductor. De no existir, debe crearlo.';
var tValidacionConductorInactivo = 'El Conductor Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.'
var tValidacionSeleccionarConductorB = 'Debe seleccionar al menos un Conductor.';
//OPERADOR
var tValidacionListaComboOperador = 'No existen o no se pueden listar operadores.';
var tValidacionOperadorNoExiste = 'El Operador seleccionado no existe, ha sido bloqueado o eliminado.'
var tValidacionMaximaCantidadOperador = 'No se puede activar el operador ya que una de sus estaciones asignadas ya tiene asignado el tope de 40 operadores.'
var tValidacionOperadorInactivo = 'El Operador Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.'
var tValidacionSeleccionarOperador = 'Debe seleccionar al menos un Operador.';
//USUARIO
var tClavesIguales = 'Las claves no coinciden';
var tClavesNoIguales = 'La nueva clave no puede ser igual a la clave actual';
var tValidacionListaComboPerfil = 'No existen o no se pueden listar perfiles.';
var tValidacionUsuarioContrata = 'Para tipo de Usuario "Contratista" debe seleccionar al menos una Compañía.';
var tValidacionUsuarioInactivo = 'El Usuario Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.';
var tValidacionUsuarioNoExiste = 'El Usuario no existe. Favor de actualizar la página.';
//ESTACION
var tValidacionListaEstaciones = 'Debe seleccionar al menos una Estación.';
var tValidacionCodEstacion = 'Debe ingresar un código válido.';
var tValidacionListaComboEstacion = 'No existen o no se pueden listar estaciones.';
var tValidacionListaComboTipoEstacion = 'No existen o no se pueden listar tipos de estación.';
var tValidacionListaComboServicioEstacion = 'No existen o no se pueden listar tipos de servicio de estación.';
var tValidacionEstacionNoExiste = 'La Estación seleccionada no existe, ha sido bloqueada o eliminada.'
//TANQUE
var tValidacionTanqueNoExiste = 'El tanque seleccionado no existe, ha sido bloqueado o eliminado.'
//TANQUE ESTACIÓN
//CONTÓMETRO
//MANGUERA
//TIPO DE MANTENIMIENTO
var tValidacionListaComboTipoMantenimientoError = 'No se puede listar los Tipos de Mantenimiento.';
var tValidacionListaComboTipoMantenimientoVacio = 'No existen Tipos de Mantenimiento a listar.';
var tValidacionSeleccionarComboTipoMantenimiento = 'Debe seleccionar un Tipo de Mantenimiento. De no existir, debe crearlo.';

//TIPO DE COMPARTIMIENTO
var tValidacionSeleccionarComboTipoCompartimiento = 'Debe seleccionar un Tipo de Compartimiento. De no existir, debe crearlo.';
var tValidacionListaComboTipoCompartimientoError = 'No se puede listar los Tipos de Compartimiento.';
var tValidacionListaComboTipoCompartimientoVacio = 'No existen Tipos de Compartimiento a listar.';
var tValidacionTipoCompartimientoInactivo = 'El Tipo Compartimiento Seleccionado se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.'

//COMPARTIMIENTO
var tValidacionListaComboCompartimientoError = 'No se puede listar los Compartimientos.';
var tValidacionListaComboCompartimientoVacio = 'No existen Compartimientos a listar.';
var tValidacionSeleccionarComboCompartimiento = 'Debe seleccionar un Compartimiento. De no existir, debe crearlo.';
var tValidacionItemGrillaYaExiste = 'El item seleccionado ya existe en la lista.';
var tValidacionCompartimientoInactivo = 'El Compartimiento Seleccionado se encuentra inhabilitado o ha sido dado de baja. Favor de actualizar la página y volver a intentarlo.';

//ASOCIACION TIPO COMPARTIMIENTO - COMPARTIMIENTO
var tValidacionListaComboAsociacionCompartimientoTipoVacio = 'No existen asociaciones de Compartimientos a Tipo de Compartimiento a listar.';
var tValidacionSeleccionAsociacionCompartimientoTipo = 'Debe seleccionar al menos una asociación de compartimiento con tipo de compartimiento.';



//ROL
var tValidacionPersonaVehiculoRol = 'Existen vehículos asignados a responsables con este rol. Para actualizar el registro, debe asignar el o los vehículos a un nuevo responsable.'
var tValidacionEstadoConfManguera = 'No pueden existir mangueras sin una configuración.';
var tValidacionListaComboManguera = 'No existen o no se pueden listar mangueras.';
var tValidacionMangueraNoExiste = 'La manguera seleccionada no existe, ha sido bloqueada o eliminada.';
var tValidacionRolInactivo = 'El Rol Seleccionado se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.'


//PERFIL
var tValidacionPerfilInactivo = 'El Perfil Seleccionado se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';
var tMensajeConfirmacionPerfil = '¿Seguro que desea eliminar el registro? Tener en cuenta que también se eliminarán todos los USUARIOS INACTIVOS relacionados a este Perfil y no se podrán recuperar.'

//PRODUCTO
var tValidacionListaComboProductosError = 'No se puede listar los productos';
var tValidacionListaComboProductosVacio = 'No existen productos a listar';
var tValidacionSeleccionarComboProductos = 'Debe seleccionar un producto. De no existir, debe crearlo.';
var tValidacioProductosDiferentes = 'El producto de la estación emisora y receptora no es el mismo.';
var tValidacionProductoInactivo = 'El Producto se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';

//TIPO DE PRODUCTO
var tValidacionListaComboTipoProductoError = 'No se puede listar los tipos de producto.';
var tValidacionListaComboTipoProductoVacio = 'No existen tipos de producto a listar.';
var tValidacionSeleccionarComboTipoProducto = 'Debe seleccionar un Tipo de Producto. De no existir, debe crearlo.';
var tValidacionTipoProductoInactivo = 'El Tipo Producto se encuentra inhabilitado o ha sido dada de baja. Favor de actualizar la página y volver a intentarlo.';

//TRANSACCIÓN
var tValidacionEstadoTransaccion = 'Una o más transacciones no se encuentran en estado "PENDIENTE".';
var tValidacionFechaTransaccion = 'Una o más transacciones están fuera del rango permitido de actualización.';
var tValidacionSeleccionarTransaccion = 'Debe seleccionar al menos una transacción';
var tValidacionErrorInsertarTransaccionManual = 'Ocurrió un error al insertar una o varias transacciones. Favor de revisar e intentar nuevamente.'

// PRECIO PERIODO
var tValidacionUltimaFechaPeriodo = 'No se puedo recuperar la última fecha del producto.';
var tValidacionListaComboPeriodo = 'No existen o no se pueden listar periodos.';
var tValidacionLimiteFechaPeriodo = 'No se pueden crear periodos mayores a 5 años de la fecha de actual.'

//LOTE
var tValidacionListaComboLoteError = 'No se puede listar los lotes.';
var tValidacionListaComboLoteVacio = 'No existen lotes a listar.';
var tValidacionErrorInsertarLote = 'No se pudo insertar el lote.';

//FECHAS Y OTROS
var tValidacionListaComboTipoBloqueo = 'No existen o no se pueden listar tipos de bloqueo.';
var tFechaActualMenorFechaIngresada = 'La Fecha Ingresada es mayor a la Fecha Actual.';
var tMensajeCreacionExitoSoloGuia = 'El registro se creo con éxito. Tener en cuenta que no tiene registros de transacción con la fecha registrada';
var tValidacionMaximoFechaTransaccion = 'Fecha inicial fuera del rango permitido (max. 15 días antes de la fecha actual).';
var tValidacionFechaMayorHoyTransaccion = 'Fecha inicial no puede ser mayor a hoy.';
var tValidacionCargaArchivo = 'No se ha seleccionado ningún archivo.';
var tValidacionArchivoPermitido = 'El archivo supera el peso máximo permitido.(1024 KB / 1MB)';
var tValidacionFormatoArchivo = 'El formato de archivo ingresado no es formato excel. (xls. / xlsx.)';
var tValidacionArchivoIncorrecto = 'El archivo ingresado no es correcto. Favor de volver a intentarlo.';
var tValidacionFormatoIncorrecto = 'Posibles causas:</br>(*) No se encontraron datos a leer</br>(*) Formato de Excel incorrecto</br>';
var tValidacionFilasExcelVacias = 'Se encontraron filas vacias entre transacciones. Favor de eliminarlas y volver a cargar la información.';
var tValidacionTransaccionFechaLimite = 'La transacción se encuentra fuera del límite permitido de actualización.';

//  TIPO INDICADORES
var tValidacionListaComboTipoIndicadorVacio = 'No existen tipos de indicadores a listar';
var tValidacionListaComboTipoIndicadorError = 'No se puede listar los tipos de indicadores.';

//  INDICADORES
var tValidacionListaComboIndicadorVacio = 'No existen indicadores a listar';
var tValidacionListaComboIndicadorError = 'No se puede listar los indicadores.';
var tCaracteresNoValidoFecha = 'Debe ingresar una fecha válida';

//MAPAS
var tValidaListaVehiculoVacia = 'No existen vehículos disponibles para asignar en el mapa';
var tValidaListaOperadorVacia = 'No existen operadores disponibles para asignar en el mapa';
var tValidaListaConductorVacia = 'No existen conductores disponibles para asignar en el mapa';
var tValidaNohaySeleccionados = 'No se selecciono ninguna restricción. Por favor, seleccione por lo menos una.'
var tValidacionListaComboMapa = 'No se pueden listar los mapas';
var tMensajeErrorYaExisteRelacion = 'El registro ya existe o la asociación entre mapa y restricción ya existe. Favor de actualizar la página y volver a intentarlo.';

//RESTRICCION
var tValidaCantidadMaximaColumnas = 'El número de restricciones para este tipo llego al limite permitido.';

//ADJUNTAR ARCHIVOS
var tValidacionSeleccionaArchivoError = 'Debe Seleccionar un archivo.'
var tValidacionExcedeTamanioArchivoError = 'Los archivos no deben exceder los 5MB.'
var tValidacionTipoArchivo = 'Tipo de archivo no permitido. Favor de seleccionar otro tipo de archivo.';
var tValidacionPesoArchivo = 'Ha superado el peso pemitido.';

var tMensajeArchivoCargadoExito = 'El archivo fue cargado correctamente.'
var tMensajeArchivoEliminadoExito = 'El archivo fue eliminado correctamente'
var tValidacionPesoArchivoAcumulado = 'La suma de los pesos de los archivos ha superado el peso pemitido. El máximo peso es 5MB'
var tMensajeCantidadArchivos = 'Solo se puede adjuntar un máximo de 3 archivos.'

//CONTROL DE ANILLOS
var tMensajeControlAnilloListaNegra = 'El anillo ingresado no se puede asignar porque se encuentra en lista negra.';
var tMensajeAnillosIguales = 'El nuevo anillo no puede ser igual al anillo actual.'
var tMensajeAnillosIgualesBD = 'El nuevo anillo no puede ser igual al anillo actual. Por favor, actualize la página.'
var tMensajeAnillosErrorYaExiste = 'El anillo ingresado ya se encuentra asignado a otro vehículo';
var tMensajeAnillosYaRegistrado = 'Ya se registro un anillo para este vehículo. Por favor, actualize la página y verifique si esta disponible para realizar un cambio.';
var tMensajeAnillosYaRetirado = 'Ya se retiro un anillo para este vehículo.';
var tMensajeAnillosYaRetiradoCambio = 'No se puede realizar un cambio de anillo a este vehículo porque este ya he sido retirado.';
var tMensajeArchivoMaximaCantidad = 'No se pueden adjuntar mas archivos.';
var tMensajeArchivoNoCorresponde = 'El archivo que desea agregar no corresponde al tipo de control actual del anillo. Por favor, actualize la página.';
var tMensajeAnillosNoExite = 'No se puede hacer un cambio de anillo cuando el anillo que desea reemplazar no existe. Por favor, actualize la página.';
var tMensajeAnillosVacio = 'El valor del anillo no puede ser cero ó vacio';
var tMensajeAnillosFecha = 'La fecha del anillo no debe ser menor al último registro';

//VOLUMEN TRANSITO

var tMensajeCamposVaciosFormula = 'Favor de completar los campos volumen guía y volumen cisterna.'
var tValidacionListaComboGuiaTransitoError = 'No se pueden listar las guías de transito.';
var tValidacionListaComboGuiaTransitoVacio = 'No existen guías de transito a listar.';
var tValidacionListaGuias = 'Debe seleccionar al menos una Guía.';
var tFechaFueraRangoTransito = 'La fecha final no puede exceder 10 años desde hoy o la fecha inicial no puede ser menor a 10 años desde hoy.';
var tMensajeConfirmacionTransito = '¿Seguro que desea eliminar el registro? Tener en cuenta que si esta asignado a volumen descarga este registro tambien se eliminará y no se podrán recuperar los datos.';
var tValidacionGuiaCompletada = 'La guía seleccionada ya se encuentra asignada a otra registro. Favor de seleccionar otra guía.';

//VOLUMEN DESCARGA
var tMensajeCamposVaciosVolumenDescarga = 'Favor de completar los campos cantidad tanque Final y cantidad tanque Inicial.'

//REPORTES GRÁFICOS

var tMensajeNoExisteTipoDespacho = 'No existe el Tipo de Despacho.';

//MENSAJE KENDO GRID PAGINABLE
var KendoMsjEmpty = "No hay datos a mostrar";
var kendoMsjPage = "Introduzca Página";
var KendoMsjOf = " de {0}";
var KendoMsjItemsPerPage = "Registros por página";
var KendoMsjFirst = "Primera";
var KendoMsjLast = "Última";
var KendoMsjNext = "Siguiente";
var KendoMsjPrevious = "Anterior";
var KendoMsjRefresh = "Actualizar";
var KendoMsjMorePages = "Más páginas";
var KendoMsjDisplay = "{0}-{1} de {2} elementos";

//MENSAJE KENDO GRID FILTERABLE
var KendoMsjClear = "Limpiar";
var KendoMsjFilter = "Filtrar";
var KendoMsjSelectedItemsFormat = "Hay {0} items seleccionados";
var KendoMsjCheckAll = "Seleccionar todo";
var KendoMsjSearch = "Buscar";

//MENSAJE KENDO GRID COLUMNMENU
var KendoMsjColumnMenuColumns = "Elegir columnas";
var KendoMsjColumnMenuFilter = "Aplicar Filtros";
var KendoMsjColumnMenuSortAscending = "Ascendente";
var KendoMsjColumnMenuSortDescending = "Descendente";
var KendoMsjSettings = "Opciones de Columna";



//var tValidacionComboProducto = 'Seleccione al menos una estación';

/*GENERICOS*/
var nTiempoCorto = 800;
var nTiempoMedio = 1600;
var nTiempoLargo = 3200;
var nTiempoMuyLargo = 7200;

/*-------------------------------------------------------------------------------------------------------------------------- COMBOS*/
var Moneda = "SOLES";
var SimboloMoneda = "U$$";
var SimboloGalones = "Gal";
var SimboloTemperatura = "°F";
var SimboloTransacciones = "Tr";
var TmensajeTodosArea = 'TODAS LAS ÁREAS';
var TidTodosArea = 0;
var TmensajeTodosCentroCostos = 'TODOS LOS CENTROS DE COSTOS';
var TidTodosCentroCostos = 0;
var TmensajeTodasCompanias = 'TODAS LAS COMPAÑÍAS';
var TidTodasCompanias = 0;
var TmensajeTodasMarcas = 'TODAS LAS MARCAS';
var TidTodasMarcas = 0;
var TmensajeTodosModelos = 'TODOS LOS MODELOS';
var TidTodosModelos = 0;
var TmensajeTodosTiposVehiculo = 'TODOS LOS TIPOS DE VEHÍCULO';
var TidTodosTiposVehiculos = 0;
var TmensajeTodasEstaciones = 'TODAS LAS ESTACIONES';
var TidTodosEstaciones = 0;
var TmensajeTodosTanques = 'TODOS LOS TANQUES';
var TidTodasTanques = 0;
var TmensajeTodasAlertas = 'TODAS LAS ALERTAS';
var TidTodasAlertas = 0;
//SOLO GOLDFIELDS
var DefaultProductId = 50;          // DB5
var DefaultCompanyId = 1;          // GOLDFIELDS
var DefaultRUC = '20507828915';     // RUC GOLDFIELDS
var DefaultBusinessName = 'GOLD FIELDS LA CIMA S.A.';
var tMensajePlacaCodigoExterno = 'La placa no puede ser igual al código del vehículo.';
//--SOLO GOLDFIELDS
/*-------------------------------------------------------------------------------------------------------------------------- MENSAJE ALERTAS*/
var BcloseButton = true;/*Mostrar boton cerrar*/
var Bdebug = false;
var BprogressBar = true;/*Mostrar barra de prgreso*/
var TpositionClass = 'toast-top-right';/*Posicion de la alerta*/
var NshowDuration = 400;/*Tiempo para mostrar el mensaje*/
var NhideDuration = 400;/*Tiempo para ocultar el mensaje*/
//var NtimeOut = 9000;/*Tiempo que se muestra el mensaje*/
//var NextendedTimeOut = 9000;/*tiempo que se extiende cuando pasas el mouse*/
var TshowEasing = "swing";
var ThideEasing = "linear";
var TshowMethod = "fadeIn";
var ThideMethod = "fadeOut";
toastr.options = { closeButton: BcloseButton, debug: Bdebug, progressBar: BprogressBar, positionClass: TpositionClass, onclick: null, showDuration: NshowDuration, hideDuration: NhideDuration, showEasing: TshowEasing, hideEasing: ThideEasing, showMethod: TshowMethod, hideMethod: ThideMethod };
/*---------------------------------------------------------------------------------------------------------------------------------------------*/
/*VALIDACION TIEMPO REAL*/
var tCampoRequerido = 'Campo Requerido';
var tRange = 'Rango de caracteres [{0}-{1}]';
var tRangeCapacidad = 'Rango de caracteres [{0}-{1}]';
var tMaxLength = 'Máximo {0} caracteres';
var tMinLength = 'Mínimo {0} caracteres';
var tValidacionNumeros = 'Se permite sólo el ingreso de números';
var tValidacionLetras = 'Se permite sólo el ingreso de letras';
var tValidacionAlfanuméricos = 'Se permite sólo el ingreso de caracteres alfanuméricos';
var tValidacionAlfanuméricosBarra = 'Se permite sólo el ingreso de números, letras y los caracteres: /';
var tValidacionAlfanuméricosBarraGuion = 'Se permite sólo el ingreso de números, letras y los caracteres: /';
var tValidacionReTexto = 'Se permite sólo el ingreso de números, letras y los caracteres: _-@"º/.-:,()+\n=';
var tCaracteresNoValido = 'Caracteres no Permitidos';
var tFormatoFechaNoValido = 'Formato de fecha no válido';
var tFechaFueraRango = 'La fecha final no puede exceder 5 años desde hoy o la fecha inicial no puede ser menor a 5 años desde hoy.';
var tDiferenciaFechas = 'La fecha inicial no puede ser mayor a la fecha final';
var tFormatoFecha = 'Formato de fecha no válido(formato de 24 horas)';
var tFechaMayorUndia = 'La transacción no puede durar más de 1 día.';
var validacionCasillasCorrectivo = 'Debe seleccionar al menos una casilla de actualización.';

/*-------------------------------------------------------------------------------------------------------------------------- REGULAR EXPRESSION*/

var ReSoloLetrasSinTildesSinCaracteresEspeciales = /^[A-Za-z]*$/;
var ReSoloAlfanumericosConEspacioYComaPuntoBarra = /^[A-Za-z0-9& ÁÉÍÓÚáéíóúñÑ,. -/]*$/;
var ReSoloAlfanumericosConEspacioBarra = /^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9-/ ]*$/;
var ReSoloAlfanumericosConBarraGuion = /^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9-/]*$/;
var ReSoloLetraYNumeros = /^[A-Za-z0-9]*$/;
var ReLetrasNumConEspacioGuionBarra = /^[A-Za-z0-9-ÁÉÍÓÚáéíóúñÑ / ]*$/;
var ReSoloLetrasYNumerosGuion = /^[A-Za-z0-9-]*$/;
var ReSoloLetrasYNumerosGuionEspacio = /^[A-Za-z0-9- ]*$/;
var ReSoloLetras = /^[A-Za-zÁÉÍÓÚáéíóúñÑ]*$/;
var ReSoloLetrasConEspacio = /^[A-Za-zÁÉÍÓÚáéíóúñÑ ]*$/;
var ReSoloLetrasyNumerosConEspacioPunto = /^[A-Za-z0-9ÁÉÍÓÚáéíóúñÑ. ]*$/;
var ReSoloLetrasConEspacioGuionBarra = /^[A-Za-z-ÁÉÍÓÚáéíóúñÑ / ]*$/;
var ReSoloNumeros = /^[0-9]*$/;
var ReSoloAlfanumericos = /^[A-Za-z0-9ÁÉÍÓÚáéíóúñÑ]*$/;
var ReSoloAlfanumericosConEspacio = /^[A-Za-z0-9ÁÉÍÓÚáéíóúñÑ ]*$/;
var ReSoloAlfanumericosConEspacioYComaPunto = /^[A-Za-z0-9ÁÉÍÓÚáéíóúñÑ,. ]*$/;
var ReSoloHexadecimal = /^[A-Fa-f0-9]*$/;
var ReTexto = /^[A-Za-z0-9& _-ÁÉÍÓÚáéíóúñÑ@"'º/.-:,()+\n=& -]*$/;
var ReFecha = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;
var ReEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
var ReRUC = /^[1,2][0][0-9]*$/;
var RePlacaVehicular = /^([A-Z0-9]{3}-\d{3,4})$/;
var ReTelefono = /^[0-9#-]*$/;
var RePassword = /^[A-Za-z0-9]*$/;
var ReSoloAlfanumericosConEspacioYComaPuntoTextArea = /^[A-Za-z0-9ÁÉÍÓÚáéíóúñÑ,. \n]*$/;
var ReSoloNumerosPunto = /^[0-9.]*$/;

/*---------------------------------------------------------------------------------------------------------------------------------------------*/
function sumarDias(fecha, dias) {
    fecha.setDate(fecha.getDate() + dias);
    return fecha;
}

var FechaHoy = new Date();
var d = FechaHoy.getDate();
var m = FechaHoy.getMonth() + 1;
var y = FechaHoy.getFullYear();
if (d < 10) {
    d = '0' + d
}
if (m < 10) {
    m = '0' + m
}
var FechaFinalReporte = d + '/' + m + '/' + y;

FechaHoy = sumarDias(FechaHoy, -90)
var d = FechaHoy.getDate();
var m = FechaHoy.getMonth() + 1;
var y = FechaHoy.getFullYear();
if (d < 10) {
    d = '0' + d
}
if (m < 10) {
    m = '0' + m
}
var FechaInicialReporte = d + '/' + m + '/' + y;

FechaHoy = sumarDias(FechaHoy, 60)
var d = FechaHoy.getDate();
var m = FechaHoy.getMonth() + 1;
var y = FechaHoy.getFullYear();
if (d < 10) {
    d = '0' + d
}
if (m < 10) {
    m = '0' + m
}
var FechaInicialReporteMes = d + '/' + m + '/' + y;

var primerDiaMes = new Date(FechaHoy.getFullYear(), FechaHoy.getMonth(), 32);


//ADICIONAL JAVIER VALVERDE.
//ARCHIVOS
var tValidacionArchivoCotVacio = '¿Seguro que desea registrar la cotización sin adjuntar ningún documento de la cotización?';
var tValidacionArchivoAnexoVacio = '¿Seguro que desea registrar la cotización sin adjuntar ningún archivo anexo?';
var tValidacionArchivoVacio = '¿Seguro que desea registrar la cotización sin adjuntar ningún archivo?';


var tValidacionArchivoOrdenVacio = '¿Seguro que desea registrar la orden de compra sin adjuntar ningún documento de orden de compra?';
var tValidacionArchivoAnexoOrdenVacio = '¿Seguro que desea registrar la orden de compra sin adjuntar ningún archivo anexo?';

var tMensajeErrorActualizarRutas = 'No se ha podido actualizar las rutas.';
var tMensajeErrorArchivoCargado = 'El archivo adjunto ya existe.';

var nroArchivosOperacionPlan = 2;
var nroArchivosOperacionAnexo1 = 5;
var nroArchivosOperacionCierre = 2;
var nroArchivosOperacionAnexo2 = 5;

//NRO COTIZACIÓN
var tValidacionNroCotizacionExiste = 'El número de cotización ingresado ya existe.';
var tValidacionCotizacionNoExiste = 'La Cotización No Existe.';

var tConfirmacionAprobarCot = '¿Seguro que desea Aprobar la Cotización Seleccionada?';
var tMensajeConfirmacionAprobarCot = '¡Cotización Aprobado con Éxito!';
var tConfirmacionDesestimarCot = '¿Seguro que desea Desestimar la Cotización Seleccionada?';
var tMensajeConfirmacionDesestimarCot = '¡Cotización Desestimada con Éxito!';

//ORDEN DE COMPRA
var tValidacionNroOrdenExiste = 'El número de orden ingresado ya existe.';