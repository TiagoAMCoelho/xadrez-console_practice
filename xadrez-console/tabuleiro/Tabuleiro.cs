namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public bool ExistePeca(Posicao p)
        {
            ValidarPosicao(p);
            return Peca(p)!=null;
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }


        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao p)
        {
            if (Peca(p) == null)
            {
                return null;
            }
            Peca aux = Peca(p);
            aux.Posicao = null;
            Pecas[p.Linha, p.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao p)
        {
            if (p.Linha < 0 || p.Linha >= Linhas || p.Coluna < 0 || p.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao p)
        {
            if (!PosicaoValida(p))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
