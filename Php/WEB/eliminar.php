<html xmlns="http://www.w3.org/1999/xhtml">
<?php
require_once("clase.contactos.php");
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

$eliminado=$contacto->eliminarContacto($id);

if($eliminado)
{
	echo "<script>location.href='consulta.php'</script>";
}

?>

</div>
</div>

