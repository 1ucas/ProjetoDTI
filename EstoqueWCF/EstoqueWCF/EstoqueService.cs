using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EstoqueWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EstoqueService" in both code and config file together.
    public class EstoqueService : IEstoqueService
    {

        private estoqueDBEntities _db;

        public Produto atualiza(Produto produto)
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Entry(produto).State = System.Data.Entity.EntityState.Modified ;
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto deleta(Produto produto)
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Set<Produto>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto deletaID(int id)
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Produto produto = _db.Set<Produto>().Find(id);
                _db.Set<Produto>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto encontra(int id)
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Produto produto = _db.Produtos.Single(x => x.id.Equals(id));
                return produto;
            }
        }

        public List<Produto> encontraTodos()
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<Produto> produtos = _db.Produtos.ToList();
                return produtos;
            }
        }

        public Produto novo(Produto produto)
        {
            using (_db = new estoqueDBEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<Produto> produtos = _db.Produtos.ToList();

                produto.id = (produtos.Count == 0)
                    ? 0
                    : produtos.Last().id+1;
                
                _db.Produtos.Add(produto);
                _db.SaveChanges();

                return produto;
            }
        }
    }
}
