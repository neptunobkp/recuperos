create table "ADMSISREC"."ARCHIVOSADJUNTOS"
(
    "Id" number(10, 0) not null, 
    "SiniestroId" number(10, 0) not null, 
    "Fecha" date not null, 
    "UsuarioId" number(10, 0) not null, 
    "Nombre" nvarchar2(200) null, 
    "Extension" nvarchar2(20) null, 
    "Url" nvarchar2(999) null, 
    "Eliminado" number(1, 0) not null,
    constraint "PK_ARCHIVOSADJUNTOS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_ARCHIVOSADJUNTOS"
/

create or replace trigger "ADMSISREC"."TR_ARCHIVOSADJUNTOS"
before insert on "ADMSISREC"."ARCHIVOSADJUNTOS"
for each row
begin
  select "ADMSISREC"."SQ_ARCHIVOSADJUNTOS".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ARCHIVOSADJUNTOS_1647119279" on "ADMSISREC"."ARCHIVOSADJUNTOS" ("SiniestroId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ARCHIVOSADJUNTOS_UsuarioId" on "ADMSISREC"."ARCHIVOSADJUNTOS" ("UsuarioId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."SINIESTROS"
(
    "Id" number(10, 0) not null, 
    "Numero" number(10, 0) not null, 
    "Riesgo" number(10, 0) not null, 
    "FechaDenuncio" date null, 
    "FechaSiniestro" date null, 
    "FechaAsignacion" date null, 
    "Prescripcion" date null, 
    "FechaUltimaActualizacion" date not null, 
    "FechaImportacion" date not null, 
    "FechaUltimoCambioEstado" date null, 
    "FechaUltimoCambioEtapa" date null, 
    "FechaRecupero" date null, 
    "Ramo" nvarchar2(100) null, 
    "Compania" number(10, 0) not null, 
    "Probabilidad" number(10, 0) not null, 
    "Provision" number(10, 0) null, 
    "GastoUf" number(10, 0) null, 
    "MontoOr" number(10, 0) null, 
    "EjecutivoId" number(10, 0) null, 
    "EstadoId" number(10, 0) null, 
    "CodigoSucursal" nvarchar2(1) null, 
    "TipoDocumento" nvarchar2(1) null, 
    "NumeroPoliza" number(19, 0) not null, 
    "NumeroItem" number(10, 0) not null, 
    "TipoDanio" nvarchar2(15) null, 
    "TipoOrden" nvarchar2(15) null, 
    "Aceptado" number(1, 0) null, 
    "ActualizadoPor" nvarchar2(90) null, 
    "Destacado" number(1, 0) not null, 
    "CompaniaTercero" nvarchar2(100) null, 
    "Region" number(10, 0) null, 
    "NumeroTercero" number(10, 0) null, 
    "FechaPromesa" date null, 
    "Monto" number(10, 0) null, 
    "Telefono" nvarchar2(100) null, 
    "FechaCarta" date null, 
    "MontoSolicitado" number(10, 0) null, 
    "EstudioAbogados" nvarchar2(100) null,
    constraint "PK_SINIESTROS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_SINIESTROS"
/

create or replace trigger "ADMSISREC"."TR_SINIESTROS"
before insert on "ADMSISREC"."SINIESTROS"
for each row
begin
  select "ADMSISREC"."SQ_SINIESTROS".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_SINIESTROS_Numero" on "ADMSISREC"."SINIESTROS" ("Numero")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_SINIESTROS_Compania" on "ADMSISREC"."SINIESTROS" ("Compania")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_SINIESTROS_EjecutivoId" on "ADMSISREC"."SINIESTROS" ("EjecutivoId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_SINIESTROS_EstadoId" on "ADMSISREC"."SINIESTROS" ("EstadoId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."USUARIOS"
(
    "Id" number(10, 0) not null, 
    "Nombres" nvarchar2(200) null, 
    "NombreIngreso" nvarchar2(200) null, 
    "Correo" nvarchar2(200) null, 
    "Contrasena" nvarchar2(200) null, 
    "Rol" nvarchar2(200) null,
    constraint "PK_USUARIOS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_USUARIOS"
/

create or replace trigger "ADMSISREC"."TR_USUARIOS"
before insert on "ADMSISREC"."USUARIOS"
for each row
begin
  select "ADMSISREC"."SQ_USUARIOS".nextval into :new."Id" from dual;
end;
/

create table "ADMSISREC"."ESTADOS"
(
    "Id" number(10, 0) not null, 
    "Nombre" nvarchar2(100) null, 
    "EtapaId" number(10, 0) not null, 
    "DiasAlerta" number(10, 0) null, 
    "Eliminado" number(1, 0) not null,
    constraint "PK_ESTADOS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_ESTADOS"
/

create or replace trigger "ADMSISREC"."TR_ESTADOS"
before insert on "ADMSISREC"."ESTADOS"
for each row
begin
  select "ADMSISREC"."SQ_ESTADOS".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ESTADOS_EtapaId" on "ADMSISREC"."ESTADOS" ("EtapaId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."ETAPAS"
(
    "Id" number(10, 0) not null, 
    "Nombre" nvarchar2(100) null, 
    "Eliminado" number(1, 0) not null,
    constraint "PK_ETAPAS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_ETAPAS"
/

create or replace trigger "ADMSISREC"."TR_ETAPAS"
before insert on "ADMSISREC"."ETAPAS"
for each row
begin
  select "ADMSISREC"."SQ_ETAPAS".nextval into :new."Id" from dual;
end;
/

create table "ADMSISREC"."TRANSICIONES"
(
    "Id" number(10, 0) not null, 
    "EstadoOrigenId" number(10, 0) not null, 
    "EstadoDestinoId" number(10, 0) not null,
    constraint "PK_TRANSICIONES" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_TRANSICIONES"
/

create or replace trigger "ADMSISREC"."TR_TRANSICIONES"
before insert on "ADMSISREC"."TRANSICIONES"
for each row
begin
  select "ADMSISREC"."SQ_TRANSICIONES".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_TRANSICIONES_EstadoOrigenId" on "ADMSISREC"."TRANSICIONES" ("EstadoOrigenId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_TRANSICIONES_Est_1210306512" on "ADMSISREC"."TRANSICIONES" ("EstadoDestinoId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."ENTRADASBITACORA"
(
    "Id" number(10, 0) not null, 
    "SiniestroId" number(10, 0) not null, 
    "UsuarioId" number(10, 0) not null, 
    "Fecha" date not null, 
    "Hora" nvarchar2(10) null, 
    "TipoBitacoraId" number(10, 0) not null, 
    "Detalle" nvarchar2(999) null,
    constraint "PK_ENTRADASBITACORA" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_ENTRADASBITACORA"
/

create or replace trigger "ADMSISREC"."TR_ENTRADASBITACORA"
before insert on "ADMSISREC"."ENTRADASBITACORA"
for each row
begin
  select "ADMSISREC"."SQ_ENTRADASBITACORA".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASBITACORA_1961181317" on "ADMSISREC"."ENTRADASBITACORA" ("SiniestroId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASBITACORA_UsuarioId" on "ADMSISREC"."ENTRADASBITACORA" ("UsuarioId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASBITACORA__477761316" on "ADMSISREC"."ENTRADASBITACORA" ("TipoBitacoraId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."TIPOSBITACORA"
(
    "Id" number(10, 0) not null, 
    "Nombre" nvarchar2(200) null, 
    "Eliminado" number(1, 0) not null,
    constraint "PK_TIPOSBITACORA" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_TIPOSBITACORA"
/

create or replace trigger "ADMSISREC"."TR_TIPOSBITACORA"
before insert on "ADMSISREC"."TIPOSBITACORA"
for each row
begin
  select "ADMSISREC"."SQ_TIPOSBITACORA".nextval into :new."Id" from dual;
end;
/

create table "ADMSISREC"."ENTRADASOBSERVACION"
(
    "Id" number(10, 0) not null, 
    "SiniestroId" number(10, 0) not null, 
    "UsuarioId" number(10, 0) not null, 
    "Fecha" date not null, 
    "Hora" nvarchar2(10) null, 
    "TipoObservacionId" number(10, 0) not null, 
    "Detalle" nvarchar2(999) null,
    constraint "PK_ENTRADASOBSERVACION" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_ENTRADASOBSERVACION"
/

create or replace trigger "ADMSISREC"."TR_ENTRADASOBSERVACION"
before insert on "ADMSISREC"."ENTRADASOBSERVACION"
for each row
begin
  select "ADMSISREC"."SQ_ENTRADASOBSERVACION".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASOBSERVAC_1973550719" on "ADMSISREC"."ENTRADASOBSERVACION" ("SiniestroId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASOBSERVAC_1362094087" on "ADMSISREC"."ENTRADASOBSERVACION" ("UsuarioId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_ENTRADASOBSERVAC_1392828260" on "ADMSISREC"."ENTRADASOBSERVACION" ("TipoObservacionId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."TIPOSOBSERVACION"
(
    "Id" number(10, 0) not null, 
    "Nombre" nvarchar2(200) null, 
    "Eliminado" number(1, 0) not null,
    constraint "PK_TIPOSOBSERVACION" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_TIPOSOBSERVACION"
/

create or replace trigger "ADMSISREC"."TR_TIPOSOBSERVACION"
before insert on "ADMSISREC"."TIPOSOBSERVACION"
for each row
begin
  select "ADMSISREC"."SQ_TIPOSOBSERVACION".nextval into :new."Id" from dual;
end;
/

create table "ADMSISREC"."INFOPERSONAS"
(
    "Id" number(10, 0) not null, 
    "Rut" number(10, 0) not null, 
    "Nombres" nvarchar2(200) null, 
    "Direccion" nvarchar2(600) null, 
    "Correo" nvarchar2(200) null, 
    "Telefono" nvarchar2(200) null, 
    "Origen" nvarchar2(200) null, 
    "FechaConsulta" date not null,
    constraint "PK_INFOPERSONAS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_INFOPERSONAS"
/

create or replace trigger "ADMSISREC"."TR_INFOPERSONAS"
before insert on "ADMSISREC"."INFOPERSONAS"
for each row
begin
  select "ADMSISREC"."SQ_INFOPERSONAS".nextval into :new."Id" from dual;
end;
/

create table "ADMSISREC"."INFOVEHICULOS"
(
    "Id" number(10, 0) not null, 
    "Patente" nvarchar2(200) null, 
    "Marca" nvarchar2(200) null, 
    "Modelo" nvarchar2(200) null, 
    "LaVersion" nvarchar2(200) null, 
    "Anio" number(10, 0) null, 
    "Color" nvarchar2(200) null, 
    "NumeroMotor" nvarchar2(200) null, 
    "NumeroChasis" nvarchar2(200) null, 
    "FechaConsulta" date not null, 
    "Origen" nvarchar2(200) null, 
    "InfoPersonaId" number(10, 0) null,
    constraint "PK_INFOVEHICULOS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_INFOVEHICULOS"
/

create or replace trigger "ADMSISREC"."TR_INFOVEHICULOS"
before insert on "ADMSISREC"."INFOVEHICULOS"
for each row
begin
  select "ADMSISREC"."SQ_INFOVEHICULOS".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_INFOVEHICULOS_InfoPersonaId" on "ADMSISREC"."INFOVEHICULOS" ("InfoPersonaId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."SINCROS"
(
    "Id" number(10, 0) not null,
    constraint "PK_SINCROS" primary key ("Id")
) segment creation immediate
/

create table "ADMSISREC"."TERCEROS"
(
    "Id" number(10, 0) not null, 
    "SiniestroId" number(10, 0) not null, 
    "Nombres" nvarchar2(200) null, 
    "Rut" number(10, 0) not null, 
    "Direccion" nvarchar2(200) null, 
    "Correo" nvarchar2(200) null, 
    "CorreoAlt" nvarchar2(200) null, 
    "Telefono" nvarchar2(200) null, 
    "TelefonoAlt" nvarchar2(200) null, 
    "Alias" nvarchar2(200) null, 
    "EsPrincipal" number(1, 0) not null,
    constraint "PK_TERCEROS" primary key ("Id")
) segment creation immediate
/

create sequence "ADMSISREC"."SQ_TERCEROS"
/

create or replace trigger "ADMSISREC"."TR_TERCEROS"
before insert on "ADMSISREC"."TERCEROS"
for each row
begin
  select "ADMSISREC"."SQ_TERCEROS".nextval into :new."Id" from dual;
end;
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_TERCEROS_SiniestroId" on "ADMSISREC"."TERCEROS" ("SiniestroId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

create table "ADMSISREC"."TERCEROVEHICULOS"
(
    "TerceroVehiculoId" number(10, 0) not null, 
    "Patente" nvarchar2(200) null, 
    "Marca" nvarchar2(200) null, 
    "Modelo" nvarchar2(200) null, 
    "LaVersion" nclob null, 
    "Anio" number(10, 0) null, 
    "Color" nvarchar2(200) null, 
    "NumeroMotor" nvarchar2(200) null, 
    "NumeroChasis" nvarchar2(200) null,
    constraint "PK_TERCEROVEHICULOS" primary key ("TerceroVehiculoId")
) segment creation immediate
/

begin
  execute immediate
  'create index "ADMSISREC"."IX_TERCEROVEHICULOS_1458305279" on "ADMSISREC"."TERCEROVEHICULOS" ("TerceroVehiculoId")';
exception
  when others then
    if sqlcode <> -1408 then
      raise;
    end if;
end;
/

alter table "ADMSISREC"."ARCHIVOSADJUNTOS" add constraint "FK_ARCHIVOSADJUNTOS_1140983013" foreign key ("SiniestroId") references "ADMSISREC"."SINIESTROS" ("Id") on delete cascade
/

alter table "ADMSISREC"."ARCHIVOSADJUNTOS" add constraint "FK_ARCHIVOSADJUNTOS_UsuarioId" foreign key ("UsuarioId") references "ADMSISREC"."USUARIOS" ("Id") on delete cascade
/

alter table "ADMSISREC"."SINIESTROS" add constraint "FK_SINIESTROS_EjecutivoId" foreign key ("EjecutivoId") references "ADMSISREC"."USUARIOS" ("Id")
/

alter table "ADMSISREC"."SINIESTROS" add constraint "FK_SINIESTROS_EstadoId" foreign key ("EstadoId") references "ADMSISREC"."ESTADOS" ("Id")
/

alter table "ADMSISREC"."ESTADOS" add constraint "FK_ESTADOS_EtapaId" foreign key ("EtapaId") references "ADMSISREC"."ETAPAS" ("Id") on delete cascade
/

alter table "ADMSISREC"."TRANSICIONES" add constraint "FK_TRANSICIONES_Esta_574880922" foreign key ("EstadoDestinoId") references "ADMSISREC"."ESTADOS" ("Id") on delete cascade
/

alter table "ADMSISREC"."TRANSICIONES" add constraint "FK_TRANSICIONES_EstadoOrigenId" foreign key ("EstadoOrigenId") references "ADMSISREC"."ESTADOS" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASBITACORA" add constraint "FK_ENTRADASBITACORA_1478001279" foreign key ("SiniestroId") references "ADMSISREC"."SINIESTROS" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASBITACORA" add constraint "FK_ENTRADASBITACORA_1210128694" foreign key ("TipoBitacoraId") references "ADMSISREC"."TIPOSBITACORA" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASBITACORA" add constraint "FK_ENTRADASBITACORA_UsuarioId" foreign key ("UsuarioId") references "ADMSISREC"."USUARIOS" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" add constraint "FK_ENTRADASOBSERVACI_964300397" foreign key ("SiniestroId") references "ADMSISREC"."SINIESTROS" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" add constraint "FK_ENTRADASOBSERVAC_1141287522" foreign key ("TipoObservacionId") references "ADMSISREC"."TIPOSOBSERVACION" ("Id") on delete cascade
/

alter table "ADMSISREC"."ENTRADASOBSERVACION" add constraint "FK_ENTRADASOBSERVAC_1418803507" foreign key ("UsuarioId") references "ADMSISREC"."USUARIOS" ("Id") on delete cascade
/

alter table "ADMSISREC"."INFOVEHICULOS" add constraint "FK_INFOVEHICULOS_InfoPersonaId" foreign key ("InfoPersonaId") references "ADMSISREC"."INFOPERSONAS" ("Id")
/

alter table "ADMSISREC"."TERCEROS" add constraint "FK_TERCEROS_SiniestroId" foreign key ("SiniestroId") references "ADMSISREC"."SINIESTROS" ("Id") on delete cascade
/

alter table "ADMSISREC"."TERCEROVEHICULOS" add constraint "FK_TERCEROVEHICULOS_1813041929" foreign key ("TerceroVehiculoId") references "ADMSISREC"."TERCEROS" ("Id")
/

create table "ADMSISREC"."__MigrationHistory"
(
    "MigrationId" nvarchar2(150) not null, 
    "ContextKey" nvarchar2(300) not null, 
    "Model" blob not null, 
    "ProductVersion" nvarchar2(32) not null,
    constraint "PK___MigrationHistory" primary key ("MigrationId", "ContextKey")
) segment creation immediate
/

