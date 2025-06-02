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
            // Verificar se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite == null)
            {
                throw new InvalidOperationException("Suite deve ser cadastrada antes de cadastrar hóspedes.");
            }

            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("A lista de hóspedes não pode ser vazia.");
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException($"A suíte comporta no máximo {Suite.Capacidade} hóspedes, mas {hospedes.Count} foram informados.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes cadastrados
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Suite deve ser cadastrada para calcular valor da diária.");
            }

            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% para reservas iguais ou superiores a 10 dias
            if (DiasReservados >= 10)
            {
                decimal desconto = valorTotal * 0.10m;
                valorTotal -= desconto;
            }

            return valorTotal;
        }
    }
}
