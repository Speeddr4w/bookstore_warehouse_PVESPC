using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRESPC
{
    class Livros
    {
        private string _nome;
        private double _preco;
        private int _numeroDePaginas;
        private string _launchDate;
        private float _scoreRating;

        public Livros()
        {
           
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                _nome = value;
            }
        }
        public double Preco
        {
            get { return _preco; }
            set
            {
                if (value >= 0.01)
                    _preco = value;
            }
        }
        public int NumeroDePaginas
        {
            get { return _numeroDePaginas; }
            set
            {
                if (_numeroDePaginas + value > 0)
                    _numeroDePaginas = value;
            }
        }
        public string LaunchDate
        {
            get { return _launchDate; }
            set
            {
                _launchDate = value;
            }
        }
        public float ScoreRating
        {
            get { return _scoreRating; }
            set
            {
                if(value >= 0 && value <=10)
                _scoreRating = value;
            }
        }

    }
}
