using Prueba.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba.Controller
{
    class InventaryController
    {
        
        public void addItem(String product, int quantity)
        {
            var context = new mydbEntities();    

            var sql = @"INSERT INTO [inventario] (PRODUCT,QUANTITY,MODIFIED_DATE) VALUES (@Product,@Quantity,@Datetime)";
            context.Database.ExecuteSqlCommand(sql,
            new SqlParameter("@Product", product),
            new SqlParameter("@Quantity", quantity),
            new SqlParameter("@Datetime", DateTime.Now)
           );
        }
        public void updateItem(int id,String product, int quantity)
        {
            var context = new mydbEntities();

            var sql = @"UPDATE [inventario] SET PRODUCT=@Product,QUANTITY=@Quantity,MODIFIED_DATE=@Datetime WHERE ID=@Id";
            context.Database.ExecuteSqlCommand(sql,
            new SqlParameter("@Product", product),
            new SqlParameter("@Quantity", quantity),
            new SqlParameter("@Datetime", DateTime.Now),
            new SqlParameter("@Id", id)
           );
        }
        public void deleteItem(int id)
        {
            var context = new mydbEntities();
            inventario itemDelete=context.inventario.Find(id);
            if (itemDelete != null) { 
                context.inventario.Remove(itemDelete);
                context.SaveChanges();   
            }
        }

        public BindingSource searchItem(BindingSource ds, String name, int lowerValue,int upperValue, DateTime from,DateTime until)
        {
            BindingSource bs = ds;
            bs.Filter = "PRODUCT like '%" + name + "%' AND QUANTITY >=" + lowerValue + "AND QUANTITY <=" + upperValue+"AND MODIFIED_DATE>='"+from.Date+"' AND MODIFIED_DATE<='"+until.Date+"'";
            return bs;
        }
        public BindingSource restore(BindingSource ds)
        {
            BindingSource bs = ds;
            bs.Filter = "";
            return bs;
        }

    }
}
