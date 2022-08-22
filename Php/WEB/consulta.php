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
<script type="text/javascript" src="js/jquery-1.11.3.min.js"></script>
<script type="text/javascript">
$(document).ready(function() {
    $("#tipo").change(function() {
		var valor = $("#tipo").val();
		if(valor!=0){
		location.href='consulta.php?filtro='+valor;	
		}
		else
		{
			location.href='consulta.php';
		}
});
});
</script>

<div id="tablita">
<h2>Contactos</h2>
<?php

$contacto = new contactos;
//ejecutando la funcion que lee la tabla

if (isset($_GET["orden"])){
	$lista=$contacto->consultaOrdenada($_GET["orden"]);
	}
	
if (isset($_GET["filtro"])){
	$lista=$contacto->consultaFiltrada($_GET["filtro"]);
	}

if(isset($_GET["filtro"]) == NULL && isset($_GET["orden"]) == NULL)
	{
	$lista=$contacto->consultaContactos();
	}

?>

<div id="selectipo"> Tipo: 
	<select id="tipo" name="tipo">
    <option>Seleccione...</option>
    <?php
	$tipo=new tipos;
	$mistipos=$tipo->consultaTipos();
	
	for ($i=0; $i<count($mistipos); $i++){
		echo "<option value=" . $mistipos[$i]['tipo_id'] . ">";
		echo $mistipos[$i]['descripcion'];
		echo "</option>";
	}
	
	?>
    <option value="0">todos</option>
    </select>
</div>



<div id="tablon">
<table border="1">
	<tr>
    	<th><a href="consulta.php?orden=id">Id</a></th>
    	<th><a href="consulta.php?orden=nombre">Nombre</a></th>
    	<th><a href="consulta.php?orden=apellido">Apellido</a></th>
        <th><a href="consulta.php?orden=telefono">Telefono</a></th>
        <th><a href="consulta.php?orden=ciudad">Ciudad</a></th>
        <th><a href="consulta.php?orden=genero">Genero</a></th>
		<th>Tipo</th>
        <th>Eliminar</th>
        <th>Editar</th>
	</tr>
    
<?php
	foreach($lista as $i){
?>
<tr>
	<td><?php echo $i['id']; ?></td>
	<td><?php echo $i['nombre']; ?></td>
	<td><?php echo $i['apellido']; ?></td>
	<td><?php echo $i['telefono']; ?></td>
	<td><?php echo $i['ciudad']; ?></td>
	<td><?php echo $i['genero']; ?></td>
	<td><?php echo $i['tipo_id']; ?></td>
    <td><a href="eliminar.php?id=<?php echo $i['id']; ?>"><img src="img/eliminar.png"></a></td>
    <td><a href="actualizar.php?id=<?php echo $i['id']; ?>">
    <img src="img/editar.png"></a></td>
</tr>
<?php
	}
?>
</table>
</div>
</div>

