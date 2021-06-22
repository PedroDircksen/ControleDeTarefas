using ControleDeTarefas.Controladores;
using ControleDeTarefas.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas
{
    public class TelaPrincipal : TelaBase
    {
        readonly TelaTarefa telaTarefa;
        readonly TelaContato telaContato;
        readonly ControladorTarefa ControladorTarefa;
        readonly ControladorContato controladorContato;
        public TelaPrincipal() : base("Tela Principal")
        {
            ControladorTarefa = new ControladorTarefa();
            controladorContato = new ControladorContato();
            telaTarefa = new TelaTarefa(ControladorTarefa);
            telaContato = new TelaContato(controladorContato);
        }

        public TelaBase ObterTela()
        {
            ConfigurarTela("Escolha uma opção: ");

            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine("Digite 1 para o Cadastro de Tarefas");
                Console.WriteLine("Digite 2 para o Cadastro de Contatos");

                Console.WriteLine("Digite S para Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = telaTarefa;
                
                if (opcao == "2")
                    telaSelecionada = telaContato;

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "S" && opcao != "s")
            {
                ApresentarMensagem("Opção inválida", TipoMensagem.Erro);
                return true;
            }
            else
                return false;
        }
    }
}
