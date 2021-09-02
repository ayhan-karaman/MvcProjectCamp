using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageService
    {
        IImageDal _imageDal;

        public ImageFileManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Add(ImageFile img)
        {
            _imageDal.Add(img);
        }

        public void Delete(ImageFile img)
        {
            _imageDal.Delete(img);
        }

        public List<ImageFile> GetAll()
        {
            return _imageDal.GetAll();
        }

        public ImageFile GetById(int id)
        {
            return _imageDal.Get(i => i.Id == id);
        }

        public void Update(ImageFile img)
        {
            _imageDal.Update(img);
        }
    }
}
