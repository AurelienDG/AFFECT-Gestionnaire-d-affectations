using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_prototype
{
    public class EST_AFFECTE : Crud<CORPS_ARMEE>
    {
        public int CodeCorpsArmee
        {
            get; set;
        }
        public string LibelleCorpsArmee
        {
            get; set;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<CORPS_ARMEE> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<CORPS_ARMEE> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
