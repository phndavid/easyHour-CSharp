# EasyHour-C-
EasyHour Functional Test in C#
![ScreenShot](https://github.com/phndavid13/EasyHour-CSharp/blob/master/Mapa%20de%20navegaci%C3%B3n/principal.JPG)
![ScreenShot](https://github.com/phndavid13/EasyHour-CSharp/blob/master/Mapa%20de%20navegaci%C3%B3n/horarios.JPG)
# Procedimiento para dar formato en excel a PDF generado por la Universidad ICESI
Programa ReadExcel

       InicializarExcel();
       
       //Crear hojas de trabajo (Se realiza sola una vez).
       
       CrearHojasDeTrabajo();
       
       //Inicializar hojas de trabajo.
       
       InicalizarHojasDeTrabajo();

Pasos:

       1. Guardar pdf en Foxit Reader txt. (Manual).
       
       2. Copiar texto del archivo txt en un archivo de excel xlsx. (Manual)
       
       3. Eliminar espacios en blanco.
       
       4. Separar el texto en dos columnas. Excel 2013 (Datos/Texto en Columnas/De ancho fijo 40) (Manual) 
       
       //EliminarEspacios(); (Preferiblemente hacerlo de forma manual)
       
       5. Borrar electivas(profesionales,biologia,humanidades,etc), extrariculares, idiomas.
 	    BorrarElectivas();
 	    
       6. Eliminar texto no deseado.
             EliminarTextoNoDeseado(range);
             
       7. Pegar semestres en diferentes hojas de trabajo.
             PegarSemestre();
             
       8. Eliminar el texto "Semestre-#" de cada hojas de trabajo. 
             ELiminarTextoSemestrePorSemestre();
             
       9. Eliminar fila de nombre extenso.
             EliminarEspaciosEnBlanco();
             
       10. Solucionar problema: Nombre de materias muy extensos.
              SolNombreExtensos();
              
       11. Borrar materias repetidas por semestre.
              BorrarMateriasRepetidasPorSemestre();
              
       12. Quitar espacios en blanco de celdas
              QuitarEspaciosEnBlancoCeldas(); 
              
       13. Lectura 
              ExtraerClasesDeGrupos();
              
       14. Guardar archivo de excel con los cambios realizados.
              SaveExcel();
