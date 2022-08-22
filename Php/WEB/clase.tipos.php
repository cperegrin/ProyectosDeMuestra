<?php

class tipos
{
	private $tipos;
	private $con;
	
	public function __construct(){
		$this->contactos=array();
		$this->con=mysqli_connect("localhost","root","","agenda"); // host, user, pass, db
	}
	
	// metodo para mostrar todos los registros de la tabla
	public function consultaTipos(){
		$consulta="SELECT * FROM tipos";
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
	
}

?>