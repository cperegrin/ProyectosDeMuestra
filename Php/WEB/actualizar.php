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

$contacto = new contactos;
$id=$_GET['id'];

$seleccionado=$contacto->buscarContacto($id);

$listo = false;

if (isset($_REQUEST['enviar'])){
	$datos=array($_REQUEST['id'], $_REQUEST['nombre'], $_REQUEST['apellido'], $_REQUEST['telefono'], $_REQUEST['ciudad'], $_REQUEST['genero'], $_REQUEST['tipo']);
	$actualizado=$contacto->editarContacto($datos, $id);
	$listo = true;
}
else
{
}
	if($listo == true)
	{
		echo "<script>location.href='consulta.php'</script>";
	}

	foreach($seleccionado as $i){
?>

<div id="formu">
	<h2>Actualizar contacto</h2>
    <form id="form1" name="form1" method="get" action="actualizar.php">
<table>
		<input type='hidden' id='id' name='id' value='<?php echo $i['id']; ?>' />
    	<th>Nombre</th>
        <td><input type='text' id='nombre' name='nombre' value='<?php echo $i['nombre']; ?>' /></td>
	</tr>
    	<th>Apellido</th>
        <td><input type="text" id="apellido" name="apellido" value='<?php echo $i['apellido']; ?>'/></td>
	</tr>
        <th>Telefono</th>
        <td><input type="text" id="telefono" name="telefono" value='<?php echo $i['telefono']; ?>'/></td>
	</tr>
        <th>Ciudad</th>
        <td><input type="text" id="ciudad" name="ciudad" value='<?php echo $i['ciudad']; ?>'/></td>
	</tr>
        <th>Genero</th>
        <td>
        <?php 
		if( $i['genero'] == "masculino")
		{
		echo "
		<input type='radio' name='genero' id='masculino' value='masculino' checked='checked'>Masculino</input>
		<input type='radio' name='genero' id='femenino' value='femenino'>Femenino</input> ";
		} 
		else
		{
		echo "
		<input type='radio' name='genero' id='masculino' value='masculino'>Masculino</input>
		<input type='radio' name='genero' id='femenino' value='femenino' checked='checked'>Femenino</input> ";
		}
		?>
		</td>
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
	</tr>
    <tr>
		<td></td><td><input type="submit" id="enviar" name="enviar" value="Enviar"/></td>
    </tr>
</table>
</form>

</div>

<?php 
} 
?>
</div>
</div>

