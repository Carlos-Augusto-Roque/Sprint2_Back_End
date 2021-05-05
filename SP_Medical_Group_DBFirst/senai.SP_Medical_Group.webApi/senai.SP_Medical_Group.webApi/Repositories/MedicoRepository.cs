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
    public class MedicoRepository : IMedicoRepository
    {
        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos
                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdClinicaNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                    CRM = m.CRM,

                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                        DescricaoEspecialidade = m.IdEspecialidadeNavigation.DescricaoEspecialidade
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia
                    }

                })

                .ToList();
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos
                
                .Include(m => m.IdEspecialidadeNavigation)

                .Include(m => m.IdClinicaNavigation)

                .Select(m => new Medico
                {
                    IdMedico = m.IdMedico,
                    NomeMedico = m.NomeMedico,
                    CRM = m.CRM,
                    
                    IdEspecialidadeNavigation = new Especialidade
                    {
                        IdEspecialidade = m.IdEspecialidadeNavigation.IdEspecialidade,
                        DescricaoEspecialidade = m.IdEspecialidadeNavigation.DescricaoEspecialidade
                    },

                    IdClinicaNavigation = new Clinica
                    {
                        IdClinica = m.IdClinicaNavigation.IdClinica,
                        NomeFantasia = m.IdClinicaNavigation.NomeFantasia
                    }
                    
                })

                .FirstOrDefault(u => u.IdMedico == id);

        }

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (medicoAtualizado.IdUsuario != 0)
            {
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
            }
            if (medicoAtualizado.IdClinica != null)
            {
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            }
            if (medicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = medicoAtualizado.NomeMedico;
            }
            if (medicoAtualizado.CRM != null)
            {
                medicoBuscado.CRM = medicoAtualizado.CRM;
            }

            ctx.Medicos.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }
    }
}
