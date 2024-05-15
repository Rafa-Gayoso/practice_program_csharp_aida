# Shopping Cart

A kata to practice TDD with test doubles.
Inputs:
-ProductName para la cesta
-DiscountCode para la cesta
-Productos Disponibles(persistencia) -> indirecto
        Revenue
        Cost
        Tax
-Descuentos disponibles(persistencia) -> indirecto
    -Discount Code
    -Amount

Estado:
    lista de productos en la cesta

Dependecnias incomodas:
    Servicio externo de pago
    Mostrar datos del carrito
    Repositorio de productos
    Repositorio de descuentos


Ejemplos:
Añadir un producto no disponible muestra mensaje de error
Añadir un producto disponible y hacer display
Añadir un producto disponible y hacer el checkout
añadir producto disponible, aplicar descuento valido y hacer display
aplicar descuento no valido muestra mensaje de error
hacer display sin tener productos
hacer checkout sin tener productos
añadir un producto y hacer checkout 2 veces
añadir n prouctos disponibles
añadir un producto con impuesto 21% y hacer display
añadir un producto con impuesto 10% y hacer chekout
añadir un producto y hacer aplicar discount 2 veces

Shopping Cart
1. What do we want to build?
A shopping cart for an online grocery shop.

1. Business rules.
    All the prices are in euros.

    The price per unit is calculated based on the product cost and the percentage
    of revenue that the company wants for that product. For instance, for a unit of
    Iceberg, the cost is 1.55€ and the desired revenue is 15%, so the price per
    unit is 1.79€.

    The price has to be rounded up. For instance, if the calculated price per unit
    of a product is 1.7825€, the expected price per unit for that product is 1.79€.
    The final price of the product is then calculated as the price per unit with
    the VAT rounded up.

    Different products may have different VAT percentages: 21% for normal products
    and 10% for first necessity products.

    Products are not allowed to have the same name.

    We can apply discounts to the shopping cart, but only one of the available
    discounts.

2. Context.
    Products (price per unit, desired revenue and tax to apply) are stored in the
    persistence.

    Available discounts are stored in the persistence.

    When we checkout the shopping cart data is sent to an external service that
    will be in charge of all the payment and billing stuff.

    At any moment the users may request to see a summary of the contents of the
    shopping cart with number of units, prices per unit, total prices, applied
    discounts and taxes. This information will be displayed on the console, but how
    the information is displayed may change in the future.

    If a not available product is added to the shopping cart, an error message is
    displayed on the console, but how this error message is notified may change in
    the future.

    If a not available discount is applied to the shopping cart, an error message
    is displayed on the console, but how this error message is notified may change
    in the future.

Constraints
This is the public interface of the  ShoppingCart :
public void AddItem(string productName)
public void Display()
public void Checkout()
public void ApplyDiscount(DiscountCode discount);