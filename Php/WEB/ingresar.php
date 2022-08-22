<html xmlns="http://www.w3.org/1999/xhtml">
<?php
require_once("clase.contactos.php");
require_once("clase.tipos.php");
?>
<head>
<meta "http-equiv="content-type" content="text/html"; charset=utf-8" />
<title>Consulta de contactos</title>
</title>
<link href="css/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>

<?php

$listo = false;

if (isset($_REQUEST['enviar'])){
	$recibidos=array($_REQUEST['nombre'], $_REQUEST['apellido'], $_REQUEST['telefono'], $_REQUEST['ciudad'], $_REQUEST['genero'], $_REQUEST['tipo']);
	$nuevo = new contactos;
	$nuevo->ingresarContacto($recibidos);

		echo "<script>location.href='consulta.php'</script>";

}
else
{

?>

<div id="formu">
	<h2>Nuevo Contacto</h2>
    <form id="form1" name="form1" method="get" action="ingresar.php">
<table>
    	<th>Nombre</th>
        <td><input type="text" id="nombre" name="nombre"/></td>
	</tr>
    	<th>Apellido</th>
        <td><input type="text" id="apellido" name="apellido"/></td>
	</tr>
        <th>Telefono</th>
        <td><input type="text" id="telefono" name="telefono"/></td>
	</tr>
        <th>Ciudad</th>
        <td><input type="text" id="ciudad" name="ciudad"/></td>
	</tr>
        <th>Genero</th>
        <td><input type="radio" name="genero" id="masculino" value="masculino" checked="checked">Masculino</input>
<input type="radio" name="genero" id="femenino" value="femenino">Femenino</input> </td>
	</tr>
    		<tr>
        <th>Tipo</th>
        <td>
		<select id="tipo" name="tipo">
	    <?php
		$tipo=new tipos;
		$mistipos=$tipo->consultaTipos();
		
		for ($i=0; $i<count($mistipos); $i++){
			echo "<option value=" . $mistipos[$i]['tipo_id'] . ">";
			echo $mistipos[$i]['descripcion'];
			echo "</option>";
		}
		
		?>
	    </select>
        </td>
    <tr>
		<td></td><td><input type="submit" id="enviar" name="enviar" value="Enviar"/></td>
    </tr>
</table>
</form>
</div>

<?php 
}
?>

</body>
</html>
