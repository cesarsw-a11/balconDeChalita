

namespace El_Balcon_de_Chalita
{
    class cliente : crud
    {
        public void asignarTablaConsulta(string tabla)
        {
            this.tablaConsulta = tabla;
        }

        public void asignarQueryEliminar(string query)
        {
            this.queryEliminar = query;
        }
       
    }
}
