<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro</title>
</head>
<body>
    <h1> Bienvenido a la pagina para registrar su partido y ver el progreso de sus documentos</h1>
    <h3>REGISTRO</h3>
    <form action="registrar.php" method="POST">
        <label for="">Usuario</label>
        <input type="text" name="usuario">
        <label for="">Contraseña</label>
        <input type="text" name="contrasenia">
        <input type="submit" value="Registrarse">
    </form>
    <h3>LOGIN</h3>
    <form action="controlindex.php" method="POST">
        <label for="">Usuario</label>
        <input type="text" name="usuario">
        <label for="">Contraseña</label>
        <input type="text" name="contrasenia">
        <input type="submit" value="Entrar">
    </form>
    
</body>
</html>