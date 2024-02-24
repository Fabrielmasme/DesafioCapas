using WebApi.database;
using WebApi.models;

public class ProductoVendidoService
{
    private readonly coderhouse _context;

    public ProductoVendidoService(coderhouse context)
    {
        this._context = context;
    }

    public List<ProductosVendido> ObtenerProductosVendidos()
    {
        return _context.ProductosVendidos.ToList();
    }

    public ProductosVendido ObtenerProductoVendidoPorId(int id)
    {
        return _context.ProductosVendidos.Where(p => p.Id == id).FirstOrDefault();
    }

    public bool AgregarProductoVendido(ProductosVendido productoVendido)
    {
        _context.ProductosVendidos.Add(productoVendido);
        _context.SaveChanges();
        return true;
    }

    public bool ActualizarProductoVendido(ProductosVendido productoVendido, int id)
    {
        var productoVendidoEncontrado = _context.ProductosVendidos.Where(p => p.Id == id).FirstOrDefault();

        if (productoVendidoEncontrado == null)
        {
            return false;
        }

        productoVendidoEncontrado.IdProducto = productoVendido.IdProducto;
        productoVendidoEncontrado.IdVenta = productoVendido.IdVenta;
        productoVendidoEncontrado.Stock = productoVendido.Stock;

        _context.ProductosVendidos.Update(productoVendidoEncontrado);
        _context.SaveChanges();
        return true;
    }

    public void EliminarProductoVendido(int id)
    {
        var productoVendido = _context.ProductosVendidos.Find(id);

        if (productoVendido != null)
        {
            _context.ProductosVendidos.Remove(productoVendido);
            _context.SaveChanges();
        }
    }

    public List<ProductosVendido> ObtenerProductosVendidosPorUsuario(int idUsuario)
    {
        return _context.ProductosVendidos.Where(pv => pv.IdProducto.HasValue && pv.Producto.IdUsuario == idUsuario).ToList();
    }
}
