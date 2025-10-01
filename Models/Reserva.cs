namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool podeHospedar = Suite is not null && hospedes.Count <= Suite.Capacidade;
            if (podeHospedar)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A quantidade de hospedes não pode exeder a capacidade da suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            
            return Hospedes is not null? Hospedes.Count:0;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados<10 ? DiasReservados*Suite.ValorDiaria*1.00M:
                                                DiasReservados *Suite.ValorDiaria*0.90M;
            return valor;
        }
    }
}