Proyecto realizado con .NET 8

Para conectar con SQLite, dirígete al archivo appsettings.json y establece la ruta en ConnectionString.

La API está configurada para ejecutarse como un servicio de Windows y levantarse por los protocolos HTTP y HTTPS. Para levantar la API en HTTPS, 
es necesario ingresar un certificado PFX o SSL en la carpeta Certificates y establecer el puerto y la clave en caso de que posea el certificado, 
de la siguiente manera:

"Port": "9081",
"CertificatePath": "Certificates\\server.pfx",
"CertificatePassword": ""

Para abrir Swagger, es necesario usar IIS Express. La API deja almacenados los logs en la ruta: ApiDevBP.Api\bin\Debug\net8.0\Logs.
