using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles
{
    public class Produits
    {
        #region Attributs

        private string _nom;
        private string _description;
        private double _prix;
        private int _pointParAchat;

        #endregion

        #region Constructeurs

        public Produits(string nom, double prix, int pointParAchat = 0, string description = "...")
        {
            this._nom = nom;
            this._prix = prix;
            this.PointParAchat = pointParAchat;
            this._description = description;
        }

        #endregion

        #region Methodes



        #endregion

        #region Getters/Setters

        public string Nom { get => _nom; set => _nom = value; }
        public string Description { get => _description; set => _description = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public int PointParAchat { get => _pointParAchat; set => _pointParAchat = value; }

        #endregion
    }
}
