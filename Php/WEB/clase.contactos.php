<?php

class contactos
{
	private $contactos;
	private $con;
	
	public function __construct(){
		$this->contactos=array();
		$this->con=mysqli_connect("localhost","root","","agenda"); // host, user, pass, db
	}
	
	// metodo para mostrar todos los registros de la tabla
	public function consultaContactos(){
		$consulta="SELECT * FROM contactos";
		$resultado=mysqli_query($this->con,$consulta);
		
		if ($resultado){
			while ($registro=mysqli_fetch_assoc($resultado)){
				$this->contactos[]=$registro;
			}
			return $this->contactos;
		}
		else
		{
			echo "error: " . mysqli_errno($this->con) . " -- " . mysqli_error($this->con);
			die;
		}
	}
	
	public function consultaOrdenada($orden){
		$consulta="SELECT * FROM contactos ORDER BY " . $orden;
		$resultado=mysqli_query($this->con,$consulta);
		
		if ($resultado){
			while ($registro=mysqli_fetch_assoc($resultado)){
				$this->contactos[]=$registro;
			}
			return $this->contactos;
		}
		else
		{
			echo "error: " . mysqli_errno($this->con) . " -- " . mysqli_error($this->con);
			die;
		}
	}
	
	public function consultaFiltrada($filtro){
		$consulta="SELECT * FROM contactos WHERE tipo_id='$filtro'";
		$resultado=mysqli_query($this->con,$consulta);
		
		if ($resultado){
			while ($registro=mysqli_fetch_assoc($resultado)){
				$this->contactos[]=$registro;
			}
			return $this->contactos;
		}
		else
		{
			echo "error: " . mysqli_errno($this->con) . " -- " . mysqli_error($this->con);
			die;
		}
	}
	
	public function buscarContacto($id){
		$consulta="SELECT * FROM contactos WHERE id=" . $id;
		$resultado=mysqli_query($this->con,$consulta);
		
		if ($resultado){
			while ($registro=mysqli_fetch_assoc($resultado)){
				$this->contactos[]=$registro;
			}
			return $this->contactos;
		}
		else
		{
			echo "error: en la busqueda" . mysqli_errno($this->con) . " -- " . mysqli_error($this->con);
			die;
		}
	}
	
	public function editarContacto($datos, $id){
		$sql="UPDATE contactos SET nombre='$datos[1]', apellido='$datos[2]', telefono='$datos[3]', ciudad='$datos[4]', genero='$datos[5]', tipo_id='$datos[6]' WHERE id='$id'";
		$resultado=mysqli_query($this->con,$sql);
		
		if(!$resultado){
			echo "error en actualizar!!!  "   .mysqli_error($this->con);
			die;
		}
		else {
		return ;
		}
	}
	
	public function eliminarContacto($id){
		$sql="DELETE from contactos WHERE id='$id'"; // id=" .$id;
		$resultado=mysqli_query($this->con,$sql);
		
		if(!$resultado){
			echo "error !!!  "   .mysqli_error($this->con);
		}
		return $resultado;
	}
	
	public function ingresarContacto($datos){
		$sql="INSERT INTO contactos (nombre,apellido,telefono,ciudad,genero,tipo_id) VALUES ('$datos[0]','$datos[1]','$datos[2]','$datos[3]','$datos[4]','$datos[5]')";
		
		$resultado = mysqli_query($this->con,$sql);
		if(!$resultado){
			echo "error !!! "  . mysqli_error($this->con);
		}
	}
}

?>