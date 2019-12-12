using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Services
{
    public class NhaCungCapS : INhaCungCapS
    {
        private readonly INhaCungCapR inhaCungCapR;
        private readonly IMapper iMapper;

        public NhaCungCapS(INhaCungCapR inhaCungCapR, IMapper mapper)
        {
            this.inhaCungCapR = inhaCungCapR;
            this.iMapper = mapper;
        }
        public void Create(NhaCungCapViewModel nhacungcap)
        {
            var nhacc = iMapper.Map<NhaCungCapViewModel, NhaCungCap>(nhacungcap);
            inhaCungCapR.Add(nhacc);
        }

        public NhaCungCapViewModel GetNhaCungCap(int? iD)
        {
            var nhacc = inhaCungCapR.getNhaCungCap(iD);
            return iMapper.Map<NhaCungCap, NhaCungCapViewModel>(nhacc);
        }

        public IEnumerable<NhaCungCapViewModel> GetNhaCungCaps()
        {
            var nhacc = inhaCungCapR.GetNhaCungCaps();
            return iMapper.Map<IEnumerable<NhaCungCap>, IEnumerable<NhaCungCapViewModel>>(nhacc);
        }

        public void remove(int? id)
        {
            inhaCungCapR.Remove(id);
        }
    }
}
