using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAtendimentoService
	{
		uint Create(Atendimento atendimento);
		void Edit(Atendimento atendimento);
		void Delete(uint id);
		Atendimento? Get(uint id);
		IEnumerable<Atendimento> GetAll();
		IEnumerable<AtendimentoDto> GetById(uint Id);
		IEnumerable<AtendimentoDto> GetByStatus(string status);
	}
}
