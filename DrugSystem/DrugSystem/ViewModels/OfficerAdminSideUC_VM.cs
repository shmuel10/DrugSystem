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
        private string _errorMessage = string.Empty;
        public string ErrorMessage {
            get { return _errorMessage; }
            set {
                _errorMessage = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }
        public void UpdateOfficer()
        {
            try
            {
                _officerAdminSide_M.UpdateOfficer(OfficerForUpdate);
                ((App)System.Windows.Application.Current).CurrentElements.CurrentOnShell =
    ((App)System.Windows.Application.Current).CurrentElements.StackOnShell.Peek();
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
