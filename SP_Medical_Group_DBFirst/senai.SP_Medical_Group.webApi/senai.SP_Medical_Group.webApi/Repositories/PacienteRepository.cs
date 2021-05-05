using Microsoft.EntityFrameworkCore;
using senai.SP_Medical_Group.webApi.Contexts;
using senai.SP_Medical_Group.webApi.Domains;
using senai.SP_Medical_Group.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SP_Medical_Group.webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Paciente
                { 
                    IdUsuario = p.IdUsuario,
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    RG = p.RG,
                    CPF = p.CPF,
                    Endereco = p.Endereco                    
                })
                
                .ToList();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Paciente
                {
                    IdUsuario = p.IdUsuario,
                    IdPaciente = p.IdPaciente,
                    NomePaciente = p.NomePaciente,
                    DataNascimento = p.DataNascimento,
                    Telefone = p.Telefone,
                    RG = p.RG,
                    CPF = p.CPF,
                    Endereco = p.Endereco
                })

                .FirstOrDefault(u => u.IdPaciente == id);

        }

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            if (pacienteAtualizado.IdUsuario != 0)
            {
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
            }
            if (pacienteAtualizado.NomePaciente != null)
            {
                pacienteBuscado.NomePaciente = pacienteAtualizado.NomePaciente;
            }
            if (pacienteAtualizado.RG != null)
            {
                pacienteBuscado.RG = pacienteAtualizado.RG;
            }
            if (pacienteAtualizado.CPF != null)
            {
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }
            if (pacienteAtualizado.Endereco != null)
            {
                pacienteBuscado.Endereco = pacienteAtualizado.Endereco;
            }

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }
    }
}
