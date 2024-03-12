using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4.Modeles
{
    public class Roulette
    {
        #region Attributs

        private Dictionary<int, int> _possibilite;
        private DateTime _dateDernierLancer;

        #endregion

        #region Constructeurs

        public Roulette()
        {
            this._possibilite = new Dictionary<int, int>();
            _possibilite.Add(5, 30);//30
            _possibilite.Add(10, 53);//23
            _possibilite.Add(25, 68);//15
            _possibilite.Add(40, 81);//13
            _possibilite.Add(60, 91);//10
            _possibilite.Add(75, 96);//5
            _possibilite.Add(100, 99);//3
            _possibilite.Add(150, 100);//1
            _dateDernierLancer = new DateTime();
        }

        #endregion

        #region Methodes

        public int Tourner()
        {
            var diffTime = this._dateDernierLancer - DateTime.Now;
            if (diffTime.TotalDays < 1)
            {
                return -1;
            }
            var random = new Random().Next(1,100);
            foreach(var (key, value) in this._possibilite)
            {
                if(random <= value)
                {
                    this._dateDernierLancer = DateTime.Now;
                    return key;
                }
            }
            return -1;
        }

        #endregion

        #region Getters/Setters

        public Dictionary<int, int> Possibilite { get => _possibilite; set => _possibilite = value; }

        #endregion
    }
}
