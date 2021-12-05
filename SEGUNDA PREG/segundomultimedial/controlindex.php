<?php
$conn = mysqli_connect("127.0.0.1", "root", "");
mysqli_select_db($conn,"segundoparcialmultimedial");
$usuario=$_POST["usuario"];
$contrasenia=$_POST["contrasenia"];
$sql="select * from usuario where nick='".$usuario;
$sql.="' and contrasenia='".$contrasenia."'";
$resultado=mysqli_query($conn, $sql);
$fila=mysqli_fetch_array($resultado);
if ($fila["nick"]==$usuario and $fila["contrasenia"]==$contrasenia)
{
	
	session_start();
	$_SESSION["usuario"]=$usuario;
	$_SESSION["tipo"]=$fila[2];
	header("Location: bandeja.php");
}
else
{
	header("Location: index.php");
}
?>
