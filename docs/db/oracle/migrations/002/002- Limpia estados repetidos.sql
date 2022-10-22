update admsisrec.estados set "Nombre" = 'Asignación Judicial' where "Id" = 114;

commit;

delete from admsisrec.transiciones where "EstadoDestinoId" = 117 or "EstadoOrigenId" = 117;

commit;

delete from admsisrec.estados where "Id" = 117;

commit;