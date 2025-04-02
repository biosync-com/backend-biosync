using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
        public class Agendamento : Entity
        {
            public DateTime Data { get; set; }
            public string Status { get; set; }
            public decimal PesoEstimadoKg { get; set; }
            public string FotoResiduos { get; set; }
            public string Observacoes { get; set; }
            public int UsuarioId { get; set; }
            public Usuario Usuario { get; set; }
            public int? ColetorId { get; set; }
            public Coletor? Coletor { get; set; }
            public int PontoDescarteId { get; set; }
            public PontoDescarte PontoDescarte { get; set; }

            public Agendamento(DateTime data, decimal pesoEstimadoKg, string fotoResiduos,
                             string observacoes, int usuarioId, int pontoDescarteId)
            {
                ValidateDomain(data, pesoEstimadoKg, fotoResiduos, observacoes);
                UsuarioId = usuarioId;
                PontoDescarteId = pontoDescarteId;
                Status = "Pendente";
            }

            private void ValidateDomain(DateTime data, decimal pesoEstimadoKg,
                                      string fotoResiduos, string observacoes)
            {
                DomainExceptionValidation.When(data < DateTime.Now,
                    "Data do agendamento não pode ser no passado");
                DomainExceptionValidation.When(pesoEstimadoKg <= 0,
                    "Peso estimado deve ser maior que zero");
                DomainExceptionValidation.When(string.IsNullOrEmpty(fotoResiduos),
                    "Foto dos resíduos é obrigatória");
                DomainExceptionValidation.When(fotoResiduos.Length > 250,
                    "URL da foto muito longa, máximo 250 caracteres");

                Data = data;
                PesoEstimadoKg = pesoEstimadoKg;
                FotoResiduos = fotoResiduos;
                Observacoes = observacoes;
            }

            public void AtribuirColetor(int coletorId)
            {
                DomainExceptionValidation.When(coletorId <= 0, "ID do coletor inválido");
                ColetorId = coletorId;
                Status = "Aceito";
            }

            public void Cancelar()
            {
                Status = "Cancelado";
            }

            public void Concluir()
            {
                Status = "Concluído";
            }
        }
}

