using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using BLL.BE;
using DrugSystem.Command;
using DrugSystem.Models;
using static BLL.BE.AuxiliaryObjects;

namespace DrugSystem.ViewModels
{
    public class OfficerAdminSideUC_VM : INotifyPropertyChanged
    {
        OfficerAdminSide_M _officerAdminSide_M;
        public ICommand FileDialogCommand { get; set; }
        public ICommand UpdateOfficerDetailes { get; set; }
        public List<Gender> Gender { get; set; }
        public Officer OfficerForUpdate { get; set; }
        BitmapImage _imageSrc;
        public BitmapImage ImageSrc {
            get { return _imageSrc; }
            set {
                _imageSrc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSrc"));
            }
        }

        public OfficerAdminSideUC_VM()
        {
            _officerAdminSide_M = new OfficerAdminSide_M();
            OfficerForUpdate = ((App)System.Windows.Application.Current).CurrentElements.OfficerSelected;
            if (OfficerForUpdate != null)
            {
                if (File.Exists(OfficerForUpdate.ProfileImagePath))
                {
                    string tempPath = System.IO.Path.GetTempFileName();
                    File.Copy(OfficerForUpdate.ProfileImagePath, tempPath, true);
                    ImageSrc = new BitmapImage(new Uri(tempPath));
                }
            }
            UpdateOfficerDetailes = new UpdateOfficerCommand(this);
            FileDialogCommand = new OpenFileDialogCommand(this);
            Gender = _officerAdminSide_M.Gender;
        }

        public void UpdateOfficer()
        {
            _officerAdminSide_M.UpdateOfficer(OfficerForUpdate);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
