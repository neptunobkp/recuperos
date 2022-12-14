
		

ALTER TABLE "ADMSISREC"."ETAPAS" DISABLE ALL TRIGGERS;
DROP SEQUENCE "ADMSISREC"."SQ_ETAPAS";
create sequence "ADMSISREC"."SQ_ETAPAS" minvalue 1 maxvalue 999999999999999999999 start with 31 increment by 1;

INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (18, 'Análisis', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (19, 'Datos Tercero', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (20, 'etapa 3', 1);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (21, 'Cobro Directo ', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (22, 'Intercompañia', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (23, 'Intercompañia BCI/ Zenit', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (24, 'Carta Intercompañia', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (25, 'Prejudicial Interno ', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (26, 'Asignación Judicial ', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (27, 'Estudios Jurídicos ', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (28, 'Cierre Estudios J. ', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (29, 'Recuperados', 0);
INSERT INTO "ADMSISREC"."ETAPAS"
   ("Id", "Nombre", "Eliminado")
 Values
   (30, 'No Aplica', 0);        
         
ALTER TABLE "ADMSISREC"."ETAPAS" ENABLE ALL TRIGGERS;

COMMIT;         

ALTER TABLE "ADMSISREC"."ESTADOS" DISABLE ALL TRIGGERS;
DROP SEQUENCE "ADMSISREC"."SQ_ESTADOS";
create sequence "ADMSISREC"."SQ_ESTADOS" minvalue 1 maxvalue 999999999999999999999 start with 118 increment by 1;


INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (118, 'Reasignación', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (119, 'Carta Enviada BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (120, 'Reasignación BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (121, 'Rechazado BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (122, 'Reconsiderar BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (123, 'Solicitud de antecedentes BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (124, 'Reconsiderar', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (26, 'Análisis', 18, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (29, 'Datos Tercero', 19, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (32, 'estado 31', 20, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (33, 'estado 32', 20, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (34, 'estado 33', 20, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (35, 'Cobro Directo', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (36, 'Posible Compañía', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (37, 'Posible Compañía BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (38, 'Generar Carta Intercompañía', 24, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (39, 'Prejudicial Interno', 25, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (40, 'Asignar Estudio Jurídico', 26, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (41, 'Estudios Jurídicos ', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (42, 'Cierre Estudios J.', 28, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (43, 'Certificar Recupero', 29, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (44, 'No Aplica', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (45, 'Sin Indicio', 18, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (46, 'Esperando Antecedentes del Asegurado', 19, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (47, 'Compromiso de Pago', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (48, 'Espera de Antecedentes del Tercero', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (49, 'Espera de Antecedentes de PT', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (50, 'Esperando Gastos', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (51, 'Esperando Antecedentes Siniestros', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (52, 'Compañía Identificada', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (53, 'Promesa de pago ', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (54, 'Espera de Antecedentes del Tercero', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (55, 'Espera de Antecedentes de PT', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (56, 'Esperando Gastos', 22, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (57, 'Esperando Antecedentes Siniestros', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (58, 'Promesa de Pago', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (59, 'Rechazada', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (60, 'Solicitud de Antecedentes', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (61, 'Espera de Antecedentes del Tercero', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (62, 'Espera de Antecedentes de PT', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (63, 'Esperando Gastos', 24, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (64, 'Esperando Antecedentes Siniestros', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (65, 'Compromiso de Pago', 25, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (66, 'Espera antecedentes del tercero', 25, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (67, 'Esperando antecedentes del PT', 25, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (68, 'Esperando gastos', 25, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (69, 'Transantiago', 26, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (70, 'Robo', 26, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (71, 'Autos para fallo', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (72, 'Avenimiento', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (73, 'Comparendo', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (74, 'Cumplimiento incidental', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (75, 'Denuncia Presentada', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (76, 'Embargo', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (77, 'Extrajudicial', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (78, 'Ha lugar demanda civil', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (79, 'Indagatoria', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (80, 'Querella y Demanda', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (81, 'Retiro de especies', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (82, 'Sentencia infraccionaría favorable', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (83, 'Tercero con compañía', 27, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (84, 'Recuperado', 29, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (85, 'Asegurado falta a la verdad ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (86, 'Cerrar, no amerita proceso judicial', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (87, 'Cierre Judicial ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (88, 'Cierre Intercompañía ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (89, 'Cierre Misma Compañía ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (90, 'Falta interés por parte del asegurado ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (91, 'No recuperado ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (92, 'Sin datos del tercero ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (93, 'Tercero inocente ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (94, 'No aplica - Denuncio mal ingresado ', 30, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (95, 'Transantiago ', 27, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (96, 'Robo ', 27, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (97, 'Compañía Identificada BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (98, 'Promesa de Pago BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (99, 'Espera de Antecedentes del Tercero BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (100, 'Espera de Antecedentes de PT BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (101, 'Esperando Gastos BCI/Zenit', 23, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (102, 'Esperando Antecedentes Siniestros BCI/Zenit', 23, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (103, 'Segundo Análisis', 18, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (104, 'Enviar Carta Culpable', 19, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (105, 'Datos Tercero Erróneo', 19, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (106, 'Carta enviada a Tercero ', 21, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (107, 'Carta Enviada', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (108, 'Reasignación', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (109, 'Rechazado', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (110, 'Reconsiderar', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (111, 'Reintento', 22, 1);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (112, 'Solicitud de Antecedentes', 22, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (113, 'Carta Enviada', 24, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (114, 'Asignación Judicial 2', 26, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (115, 'Certificar Cierre Estudios J.', 28, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (116, 'Tercero con Compañía', 27, 0);
INSERT INTO "ADMSISREC"."ESTADOS"
   ("Id", "Nombre", "EtapaId", "Eliminado")
 Values
   (117, 'Cobro Directo 2', 21, 0);

ALTER TABLE "ADMSISREC"."ESTADOS" ENABLE ALL TRIGGERS;

COMMIT;         


ALTER TABLE "ADMSISREC"."TRANSICIONES" DISABLE ALL TRIGGERS;
DROP SEQUENCE "ADMSISREC"."SQ_TRANSICIONES";
create sequence "ADMSISREC"."SQ_TRANSICIONES" minvalue 1 maxvalue 999999999999999999999 start with 908 increment by 1;


INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (126, 42, 44, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (127, 42, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1068, 26, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1069, 26, 70);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1070, 26, 69);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1071, 26, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1072, 26, 29);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1073, 26, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1074, 26, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1075, 26, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1076, 26, 94, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1077, 26, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1088, 103, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1089, 103, 70);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1090, 103, 69);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1091, 103, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1092, 103, 29);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1093, 103, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1094, 103, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1095, 103, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1096, 103, 94, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1097, 103, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1098, 45, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1099, 45, 70);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1100, 45, 69);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1101, 45, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1102, 45, 29);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1103, 45, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1104, 45, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1105, 45, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1106, 45, 94, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1107, 45, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1108, 29, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1109, 29, 51);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1110, 29, 46);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1111, 29, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1112, 29, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1113, 29, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1114, 29, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1115, 29, 92, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1116, 29, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1117, 29, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1118, 105, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1119, 105, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1120, 105, 46);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1121, 105, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1122, 105, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1123, 105, 92, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1124, 105, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1125, 105, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1126, 105, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1127, 105, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1128, 46, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1129, 46, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1130, 46, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1131, 46, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1132, 46, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1133, 46, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1134, 46, 92, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1135, 46, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1136, 46, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1137, 104, 106);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1258, 52, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1259, 52, 55);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1260, 52, 57);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1261, 52, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1262, 52, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1263, 55, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1264, 55, 57);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1265, 55, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1266, 55, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1267, 57, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1268, 57, 55);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1269, 57, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1270, 57, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1286, 108, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1287, 108, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1288, 108, 52);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1289, 108, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1290, 108, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1291, 108, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1292, 109, 108);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1293, 109, 110);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1294, 109, 88, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1295, 109, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1296, 109, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1297, 110, 52);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1298, 110, 53);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1299, 110, 109);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1300, 110, 88, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1301, 110, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1302, 110, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1303, 111, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1304, 111, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1305, 111, 29);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1306, 111, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1307, 111, 52);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1308, 111, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1309, 111, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1310, 111, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1311, 36, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1312, 36, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1313, 36, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1314, 36, 52);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1315, 36, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1316, 36, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1317, 36, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1421, 37, 103);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1422, 37, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1423, 37, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1424, 37, 97);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1425, 37, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1426, 37, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1427, 37, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1442, 62, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1443, 62, 64);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1444, 62, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1445, 62, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1446, 64, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1447, 64, 62);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1448, 64, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1449, 64, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1458, 118, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1459, 118, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1460, 118, 52);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1461, 118, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1462, 118, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1463, 118, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1464, 118, 97);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1557, 114, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1558, 114, 44, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1559, 114, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1560, 114, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1561, 114, 117);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1562, 114, 41);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1563, 40, 41);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1564, 40, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1565, 40, 44, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1566, 40, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1567, 40, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1568, 69, 41);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1569, 70, 41);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1620, 71, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1621, 71, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1622, 71, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1623, 71, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1624, 71, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1625, 71, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1626, 71, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1627, 71, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1628, 71, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1629, 71, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1630, 71, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1631, 71, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1632, 71, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1633, 71, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1634, 71, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1635, 71, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1636, 72, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1637, 72, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1638, 72, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1639, 72, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1640, 72, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1641, 72, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1642, 72, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1643, 72, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1644, 72, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1645, 72, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1646, 72, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1647, 72, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1648, 72, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1649, 72, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1650, 72, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1651, 72, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1652, 73, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1653, 73, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1654, 73, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1655, 73, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1656, 73, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1657, 73, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1658, 73, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1659, 73, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1660, 73, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1661, 73, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1662, 73, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1663, 73, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1664, 73, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1665, 73, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1666, 73, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1667, 73, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1668, 74, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1669, 74, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1670, 74, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1671, 74, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1672, 74, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1673, 74, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1674, 74, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1675, 74, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1676, 74, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1677, 74, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1678, 74, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1679, 74, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1680, 74, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1681, 74, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1682, 74, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1683, 74, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1684, 75, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1685, 75, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1686, 75, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1687, 75, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1688, 75, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1689, 75, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1690, 75, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1691, 75, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1692, 75, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1693, 75, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1694, 75, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1695, 75, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1696, 75, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1697, 75, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1698, 75, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1699, 75, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1700, 76, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1701, 76, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1702, 76, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1703, 76, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1704, 76, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1705, 76, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1706, 76, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1707, 76, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1708, 76, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1709, 76, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1710, 76, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1711, 76, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1712, 76, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1713, 76, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1714, 76, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1715, 76, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1716, 77, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1717, 77, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1718, 77, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1719, 77, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1720, 77, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1721, 77, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1722, 77, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1723, 77, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1724, 77, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1725, 77, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1726, 77, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1727, 77, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1728, 77, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1729, 77, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1730, 77, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1731, 77, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1732, 78, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1733, 78, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1734, 78, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1735, 78, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1736, 78, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1737, 78, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1738, 78, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1739, 78, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1740, 78, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1741, 78, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1742, 78, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1743, 78, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1744, 78, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1745, 78, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1746, 78, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1747, 78, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1748, 79, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1749, 79, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1750, 79, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1751, 79, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1752, 79, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1753, 79, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1754, 79, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1755, 79, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1756, 79, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1757, 79, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1758, 79, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1759, 79, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1760, 79, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1761, 79, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1762, 79, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1763, 79, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1764, 80, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1765, 80, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1766, 80, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1767, 80, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1768, 80, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1769, 80, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1770, 80, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1771, 80, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1772, 80, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1773, 80, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1774, 80, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1775, 80, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1776, 80, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1777, 80, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1778, 80, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1779, 80, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1780, 81, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1781, 81, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1782, 81, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1783, 81, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1784, 81, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1785, 81, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1786, 81, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1787, 81, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1788, 81, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1789, 81, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1790, 81, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1791, 81, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1792, 81, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1793, 81, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1794, 81, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1795, 81, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1796, 82, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1797, 82, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1798, 82, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1799, 82, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1800, 82, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1801, 82, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1802, 82, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1803, 82, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1804, 82, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1805, 82, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1806, 82, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1807, 82, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1808, 82, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1809, 82, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1810, 82, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1811, 82, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1812, 116, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1813, 116, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1814, 116, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1815, 116, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1816, 116, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1817, 116, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1818, 116, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1819, 116, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1820, 116, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1821, 116, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1822, 116, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1823, 116, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1824, 116, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1825, 116, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1826, 116, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1827, 116, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1828, 115, 114);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1829, 115, 117);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1830, 115, 87, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1831, 115, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1832, 115, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2097, 122, 98);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1835, 85, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1836, 85, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1837, 87, 114);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1838, 87, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1839, 87, 114);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1840, 87, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1841, 86, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1842, 88, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1843, 90, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1844, 90, 108);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (1846, 44, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1847, 44, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1848, 94, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1849, 91, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1850, 92, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (1851, 93, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2257, 49, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2258, 49, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2259, 49, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2260, 49, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2261, 49, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2262, 49, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2263, 49, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2264, 49, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2265, 49, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2266, 49, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2267, 49, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2268, 49, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2269, 51, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2270, 51, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2271, 51, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2272, 51, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2273, 51, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2274, 51, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2275, 51, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2276, 51, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2277, 51, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2278, 51, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2279, 51, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2280, 51, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2281, 51, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2291, 117, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2292, 117, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2293, 117, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2294, 117, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2295, 117, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2296, 117, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2297, 117, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2298, 117, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2299, 117, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2300, 117, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2301, 117, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2302, 117, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2303, 117, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2113, 124, 59);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2114, 124, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2115, 124, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2116, 124, 88, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2131, 97, 100);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2132, 97, 102);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2098, 122, 121);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2099, 122, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2100, 122, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2112, 124, 58);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2133, 97, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2134, 97, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2135, 97, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2136, 100, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2137, 100, 102);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2138, 100, 87, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2139, 100, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2140, 100, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2141, 102, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2142, 102, 100);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2143, 102, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2130, 97, 113);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2144, 102, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2145, 102, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2146, 59, 118);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2147, 59, 88, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2148, 59, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2149, 59, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2150, 59, 124);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2197, 35, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2198, 35, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2092, 121, 122);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2093, 121, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2094, 121, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2095, 121, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2096, 121, 120);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2199, 35, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2200, 35, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2201, 35, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2202, 35, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2203, 35, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2204, 35, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2205, 35, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2206, 35, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2207, 35, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2208, 35, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2209, 35, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2211, 47, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2212, 47, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2213, 47, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2214, 47, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2215, 47, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2216, 47, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2217, 47, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2245, 106, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2246, 106, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2247, 106, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2248, 106, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2249, 106, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2250, 106, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2210, 47, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2251, 106, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2252, 106, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2253, 106, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2254, 106, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2255, 106, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2256, 106, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2231, 48, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2232, 48, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2233, 48, 48);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2234, 48, 50);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2235, 48, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2236, 48, 104);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2237, 48, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2238, 48, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2239, 48, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2240, 48, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2241, 48, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2242, 48, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2243, 48, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2244, 106, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2318, 112, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2319, 112, 53);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2320, 112, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2321, 112, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2322, 112, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2323, 112, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2324, 119, 98);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2325, 119, 120);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2326, 119, 121);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2327, 119, 123);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2328, 119, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2329, 119, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2330, 119, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2359, 58, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2360, 58, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2361, 58, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2362, 58, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2363, 58, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2364, 58, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2365, 58, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2366, 58, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2368, 60, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2369, 60, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2370, 60, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2371, 60, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2372, 65, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2373, 65, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2374, 65, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2375, 65, 86, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2332, 98, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2333, 98, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2334, 98, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2335, 98, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2336, 98, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2337, 98, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2338, 98, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2059, 120, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2060, 120, 35);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2061, 120, 97);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2062, 120, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2063, 120, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2064, 120, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2065, 120, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2282, 50, 47);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2283, 50, 49);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2284, 50, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2285, 50, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2286, 50, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2287, 50, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2288, 50, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2289, 50, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2290, 50, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2304, 107, 53);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2305, 107, 108);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2306, 107, 109);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2307, 107, 112);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2308, 107, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2309, 107, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2310, 107, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2311, 53, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2312, 53, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2313, 53, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2314, 53, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2315, 53, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2316, 53, 39);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2317, 53, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2331, 98, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2351, 113, 58);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2352, 113, 118);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2353, 113, 59);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2354, 113, 60);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2355, 113, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2356, 113, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2345, 123, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2346, 123, 98);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2347, 123, 89, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2348, 123, 91, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2349, 123, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2350, 123, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2357, 113, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2358, 113, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2367, 60, 58);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2376, 65, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2377, 65, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2378, 65, 67);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2379, 65, 68);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2380, 65, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2381, 66, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2382, 66, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2383, 66, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2384, 66, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2385, 66, 86, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2386, 66, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2387, 66, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2388, 66, 65);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2389, 66, 67);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2390, 66, 68);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2391, 66, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2392, 67, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2393, 67, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2394, 67, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2395, 67, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2396, 67, 86, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2397, 67, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2398, 67, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2399, 67, 65);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2400, 67, 66);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2401, 67, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2402, 68, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2403, 68, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2404, 68, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2405, 68, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2406, 68, 86, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2407, 68, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2408, 68, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2409, 68, 65);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2410, 68, 66);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2411, 68, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2412, 39, 40);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2413, 39, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2414, 39, 36);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2415, 39, 37);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2416, 39, 85, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2417, 39, 86, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2418, 39, 90, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2419, 39, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2420, 39, 65);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2421, 39, 66);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2422, 39, 67);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2423, 39, 68);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2424, 39, 84, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2425, 41, 115);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2426, 41, 105);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2427, 41, 71);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2428, 41, 72);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2429, 41, 73);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2430, 41, 74);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2431, 41, 75);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2432, 41, 76);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2433, 41, 77);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2434, 41, 78);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2435, 41, 79);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2436, 41, 80);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2437, 41, 81);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2438, 41, 82);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId")
 Values
   (2439, 41, 116);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2440, 41, 93, 1);
INSERT INTO "ADMSISREC"."TRANSICIONES"
   ("Id", "EstadoOrigenId", "EstadoDestinoId", "Aprobable")
 Values
   (2441, 41, 84, 1);


ALTER TABLE "ADMSISREC"."TRANSICIONES" ENABLE ALL TRIGGERS;



Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (21, 'ESTADO', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (22, 'Datos tercero', 1);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (23, 'Datos terceros', 1);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (24, 'DICOM', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (25, 'ESTUDIO', 1);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (26, 'GUARDAR', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (27, 'Intercompañía', 1);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (28, 'OBSERVACIONES', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (29, 'Promesa pago', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (30, 'TERCERO', 1);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (31, 'Reasignacion', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (1, 'Cambio de estado', 0);
Insert into "ADMSISREC"."TIPOSBITACORA" 
   ("Id", "Nombre", "Eliminado")
 Values
   (2, 'Cambio de probabilidad', 0);
COMMIT;

Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (8, 'Teléfono no corresponde al Tercero', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (7, 'Rechazo de transición', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (1, 'Fecha compromiso pago', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (2, 'Teléfono ocupado', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (3, 'Teléfono fuera de servicio', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (4, 'Buscar datos en Dicom', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (5, 'Enviar carta de cobro', 0);
Insert into "ADMSISREC"."TIPOSOBSERVACION"
   ("Id", "Nombre", "Eliminado")
 Values
   (6, 'Contactado', 0);
COMMIT;


Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (250, 'Judith Cid  Bernales', '13932272', 'judith.cid@bciseguros.com', '123', 
    'PrejudicialInterno', '13932272');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (283, 'Servicios y Asesorias Birkner y Cia Ltda', '77976040', 'sincorreo16@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '77976040');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (248, 'Johanna Araya  López', '14259654', 'johanna.araya@bciseguros.com', '123', 
    'CobroDirecto', '14259654');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (256, 'Sebastian Ureta Seguel', '17278547', 'sebastian.ureta@bciseguros.com', '123', 
    'AdmLegal', '17278547');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (269, 'Inzunza y Mohr Limitada', '76403285', 'sincorreo105@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76403285');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (270, 'Jacqueline Hernández  Henríquez', '16583764', 'sincorreo9@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '16583764');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (271, 'Jose Antonio Ventura Jordorkovsky', '10729851', 'correo105@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '10729851');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (272, 'Juan Pablo Campos  Ruljancic', '13525798', 'sincorreo18@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '13525798');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (246, 'Cinthya Ramis Guzman', '16513967', 'cinthya.ramis@bciseguros.com', '123', 
    'Supervisor', '16513967');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (247, 'Paola Riquelme Soto', '12864446', 'paola.riquelme@bciseguros.com', '123', 
    'Analista', '12864446');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (252, 'Fabian Fuentes', '19637543', 'fabian.fuentes@bciseguros.com', '123', 
    'Intercompania', '19637543');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (253, 'Mario Marquez  Cuevas', '17701065', 'mario.marquez@bciseguros.com', '123', 
    'Intercompania', '17701065');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (254, 'Marta Barahona', '18294825', 'marta.barahona@bciseguros.com', '123', 
    'Intercompania', '18294825');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (255, 'Marisol Villalobos', '11669670', 'marisol.villalobos@bciseguros.com', '123', 
    'AdmLegal', '11669670');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (257, 'Auditalex Asesorias ltda', '76480262', 'sincorreo100@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76480262');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (259, 'Cesar Vicuna y Asociados Abogados', '78856280', 'sincorreo31@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '78856280');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (260, 'Covarrubias y Cia abogados SPA', '77141315', 'sincorreo102@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '77141315');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (261, 'Coberturas Legales SPA Legales Spa', '76891085', 'sincorreo22@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76891085');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (262, 'Cristian Antonio Hernández  Bulnes', '13903239', 'sincorreo36@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '13903239');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (263, 'Daniel Martorel', '15638243', 'sincorreo5@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '15638243');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (245, 'Mariela Fuentes Gálvez', '12851962', 'mariela.fuentes@bciseguros.com', '123', 
    'Supervisor', '12851962');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (251, 'Jaime Donoso  Altamirano', '16297247', 'jaime.donoso@bciseguros.com', '123', 
    'AdmPrejudicialInter', '16297247');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (264, 'Estudio Juridico Capital y Gestion SA Gestión SA', '76171043', 'sincorreo15@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76171043');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (265, 'Felipe Palma', '14022542', 'sincorreo2@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '14022542');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (266, 'Francisco Aldunate Ramos', '11610807', 'sincorreo103@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '11610807');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (267, 'Gustavo Alejandro  Díaz  Bustamanete', '12180979', 'sincorreo34@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '12180979');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (268, 'Gustavo Becerra Arevalo Servicios Juridicos EIRL', '76104971', 'sincorreo104@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76104971');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (273, 'Kenneth Romero  Quiroz', '13270763', 'sincorreo30@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '13270763');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (274, 'Manuel Martinez Sanhueza Abogado y Asociados SPA', '76640583', 'sincorreo106@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76640583');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (275, 'Montt Gestion y Estrategia Ltda', '76070253', 'sincorreo37@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76070253');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (276, 'Pamela Fuentes  Boscmann', '14148994', 'sincorreo7@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '14148994');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (277, 'Pedro Antonio Fuentes Araya', '9062051', 'sincorreo20@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '9062051');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (278, 'Ramon Alejandro Miranda  Tapia', '14111663', 'sincorreo28@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '14111663');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (279, 'Rodrigo  Meneses  Flores', '12614014', 'sincorreo23@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '12614014');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (281, 'Sebastian Quiroga  Echeverría', '17269927', 'sincorreo6@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '17269927');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (282, 'Sebastian Valles', '17378811', 'sincorreo25@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '17378811');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (285, 'UMS Abogados', '13316609', 'sincorreo11@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '13316609');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (258, 'Carrasco y cia', '76062595', 'sincorreo101@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76062595');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (280, 'Rodrigo Tejeda Bertens', '10383277', 'sincorreo8@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '10383277');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (284, 'Soc Asesoria y Servicios legales Puerto Varas Ltda  y Servicios Leg', '76242978', 'sincorreo1@sincorreo.cl', '123', 
    'EstudioJuridicoExter', '76242978');
Insert into USUARIOS
   ("Id", "Nombres", "NombreIngreso", "Correo", "Contrasena", 
    "Rol", "Rut")
 Values
   (249, 'Andres Caceres Rojas', '17365430', 'andres.caceres@bciseguros.com', '123', 
    'PrejudicialInterno', '17365430');
COMMIT;


COMMIT;

GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."ETAPAS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."ESTADOS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."SINIESTROS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."ENTRADASBITACORA" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."ENTRADASOBSERVACION" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."TIPOSOBSERVACION" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."USUARIOS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."TRANSICIONES" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."TIPOSBITACORA" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."INFOPERSONAS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."INFOVEHICULOS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."SINCROS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."TERCEROS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."TERCEROVEHICULOS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."ARCHIVOSADJUNTOS" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."SOLICITUDESVISTO" to "USRSISREC";
GRANT SELECT, INSERT, UPDATE, DELETE ON "ADMSISREC"."__MigrationHistory" to "USRSISREC";

COMMIT;  