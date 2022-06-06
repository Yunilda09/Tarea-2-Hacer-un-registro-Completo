using Microsoft.EntityFrameworkCore;

public class NombresBLL
{
    private Contexto _contexto;
    public NombresBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public bool Guardar(Nombres nombre)
    {
        if (!Existe(nombre.NombreId))
            return Insertar(nombre);
        else return Modificar(nombre);
    }
    public bool Existe(int nombreId)
    {
        return _contexto.Nombres.Any(n => n.NombreId == nombreId);
    }
    private bool Insertar(Nombres nombre)
    {
        _contexto.Nombres.Add(nombre);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }
    private bool Modificar(Nombres nombre)
    {
        _contexto.Entry(nombre).State = EntityState.Modified;
        int cantidad = _contexto.SaveChanges();
        return ((byte)cantidad) > 0;
    }
    public Nombres Buscar(int nombreId)
    {
        var nombre = _contexto.Nombres.Find(nombreId);
        return nombre;
    }
    public bool Eliminar(int Id)
    {
        bool paso = false; try
        {
            var nombre = _contexto.Nombres.Find(Id);
            if (nombre != null)
            {
                _contexto.Nombres.Remove(nombre);
                paso = _contexto.SaveChanges() > 0;
            }
        }
        catch (System.Exception)
        { throw; }
        return paso;
    }
    public List<Nombres> GetNombres()
    {
        return _contexto.Nombres.ToList();
    }
}
