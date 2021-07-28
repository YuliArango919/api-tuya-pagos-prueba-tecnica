# api-tuya-pagos-prueba-tecnica

Una vez se tengan clonados los dos repositorios(api-tuya-pagos-prueba-tecnica y api-tuya-logistica-prueba-tecnica),
seguir las siguientes instrucciones:

1. Ejecutar en local el Api de pagos: App.Tuya.Pagos.Api (Será el Api que factura y manda a crear el pedido)
2. Ejecutar en local el Api de logística: App.Tuya.Logistica.Api (Será el Api que guarda el pedido en Bd)
3. En el Api de pagos se encontrará un método llamado facturar (Este suma el precio de los productos y manda a crear el pedido)
4. El método "Facturar" recibe un Json en el body, en la parte de abajo de este documento se adjunta un Json de prueba para este método
5. Una vez el Api de pagos ejecute el método facturar, deberá invocar el Api de logística automáticamente que se encargará de 
crear el pedido en base de datos
6. Una vez almacenado el pedido, el Api de logística devolverá como respuesta el pedido que se acaba de crear


Json de prueba:

{
    "codigoPedido": "P001",
  "datosCliente": {
    "documentoIdentidad": "10175478952",
    "nombre": "Cliente de prueba",
    "direccion": "Cll 8 # 4 - 23 APT 1",
    "codigoPostal": "502545",
	"correo": "test@test.com",
    "telefono": "3014078547"
  },
    "products": [
    {
      "codigo": "A01",
      "nombre": "Producto 1",
      "precio": 100000,
      "cantidad": 2,
      "descripcion": "Test 1"
    },
                {
      "codigo": "A02",
      "nombre": "Producto 2",
      "precio": 1500000,
      "cantidad": 1,
      "descripcion": "Test 2"
    },
                {
      "codigo": "A03",
      "nombre": "Producto 3",
      "precio": 15000,
      "cantidad": 3,
      "descripcion": "Test 3"
    }
    ]
}