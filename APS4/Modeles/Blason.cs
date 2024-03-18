using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles
{
    public class Blason
    {
        #region Attributs

        private int _id;
        private string _nomBlason;
        private float _montantAchat;
        public static List<Blason> listBlason = new List<Blason>();

        #endregion

        #region Constructeurs
        public Blason(string nomBlason, float montantAchat)
        {
            _nomBlason = nomBlason;
            _montantAchat = montantAchat;
            listBlason.Add(this);
        }
        #endregion

        #region Getter/Setter

        public int Id { get => _id; set => _id = value; }
        public string NomBlason { get => _nomBlason; set => _nomBlason = value; }
        public float MontantAchat { get => _montantAchat; set => _montantAchat = value; }

        #endregion

    }
}
