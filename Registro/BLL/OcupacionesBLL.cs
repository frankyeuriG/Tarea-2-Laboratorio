using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Registro.BLL
{

public class OcupacionesBLL{
    private Contexto _contexto;

    public OcupacionesBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int OcupacionId)
    {
        return _contexto.Ocupaciones
            .Any(o => o.OcupacionId == OcupacionId);
    }
    private bool Insertar(Ocupaciones ocupacion)
    {
        _contexto.Ocupaciones.Add(ocupacion);
        return _contexto.SaveChanges() > 0;
    }

    private bool Modificar (Ocupaciones ocupacion)
    {
        _contexto.Entry(ocupacion).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar (Ocupaciones ocupacion)
    {
        if (!Existe(ocupacion.OcupacionId))
            return this.Insertar(ocupacion);
        else 
            return this.Modificar(ocupacion);
    }

    public bool Eliminar (Ocupaciones ocupacion)
    {
        _contexto.Entry(ocupacion).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }
    public Ocupaciones? Buscar (int OcupacionId)
    {
        return _contexto.Ocupaciones
        .Where (o => o.OcupacionId == OcupacionId )
        .AsNoTracking()
        .SingleOrDefault();
    }

     

}

}