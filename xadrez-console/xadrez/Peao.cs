using tabuleiro;
namespace xadrez
{
    class Peao : Peca
    {

        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != this.Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #jogadaespecial En Passant
                if (Posicao.Linha == 3)
                {
                    Posicao esq = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esq) && ExisteInimigo(esq) && Tab.Peca(esq) == partida.VulneravelEnPassant)
                    {
                        mat[esq.Linha - 1, esq.Coluna] = true;
                    }
                    Posicao dir = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(dir) && ExisteInimigo(dir) && Tab.Peca(dir) == partida.VulneravelEnPassant)
                    {
                        mat[dir.Linha - 1, dir.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                // #jogadaespecial En Passant
                if (Posicao.Linha == 4)
                {
                    Posicao esq = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(esq) && ExisteInimigo(esq) && Tab.Peca(esq) == partida.VulneravelEnPassant)
                    {
                        mat[esq.Linha + 1, esq.Coluna] = true;
                    }
                    Posicao dir = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(dir) && ExisteInimigo(dir) && Tab.Peca(dir) == partida.VulneravelEnPassant)
                    {
                        mat[dir.Linha + 1, dir.Coluna] = true;
                    }
                }
            }

            return mat;

        }




    }
}
