<?php
//include "conexion.inc.php";
$conn = mysqli_connect("127.0.0.1", "root", "");
mysqli_select_db($conn,"segundoparcialmultimedial");
$usuario= $_POST["usuario"];
$contrasenia = $_POST["contrasenia"];
$sql="insert into usuario(nick,contrasenia) values('".$usuario."','".$contrasenia."')";

$sql3="select CONVERT(se.numerotram, SIGNED INTEGER) as numtra from seguimiento se ORDER by numtra";

$resultado=mysqli_query($conn, $sql3);
$fila=mysqli_fetch_all($resultado);
$numero = count($fila); 


$sql2="insert into seguimiento values('".($numero+1)."','".$usuario."','P1','".date('d/m/Y'). "','".date('d/m/Y')."','')";
$sql4="insert into seguimiento values('".($numero+1)."','comite','P2','".date('d/M/Y')."','','".$usuario."')";

if ($conn->query($sql2) === TRUE && $conn->query($sql) === TRUE && $conn->query($sql4) === TRUE) {
    header("Location: index.php" );
} else {
echo "Error: " . $sql2 . "<br>" . $conn->error;
echo "Error: " . $sql . "<br>" . $conn->error;
echo "Error: " . $sql3 . "<br>" . $conn->error;
} 

?>