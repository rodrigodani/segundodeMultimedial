<?php
session_start();
$conn = mysqli_connect("127.0.0.1", "root", "");
mysqli_select_db($conn,"segundoparcialmultimedial");
$sql="select * from seguimiento where usuario='".$_SESSION["usuario"]."'";
$sql.="and fecha_fin=''";
$resultado=mysqli_query($conn, $sql);
?>
<h1><?php echo "sesion de:  ".$_SESSION["usuario"] ?></h1>
<h4><?php echo "Bandeja de Usuario" ?></h4>
<table>
<tr>
	<td>Tramite</td>
	<!-- //<td>Flujo</td> -->
	<td>Proceso</td>
	<td>Fecha Inicio</td>
	<td>Accion</td>
</tr>
<?php
$filas = mysqli_fetch_all($resultado);
foreach($filas as $fila)
{
	echo "<tr>";
	echo "<td>".$fila[0]."</td>";
	//echo "<td>".$fila["flujo"]."</td>";
	echo "<td>".$fila[2]."</td>";
	echo "<td>".$fila[3]."</td>";
	echo "<td><a ";
	
	echo "href='desflujo.php?flujo=F1&proceso=$fila[2]&tramite=$fila[0]&usuarante=$fila[5]'";
	echo ">Mostrar<a/></td>";
	echo "</tr>";
	
}
?>
</table>