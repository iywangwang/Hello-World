using CommunityToolkit.Mvvm.Input;
using IntelligentPlant.Command;
using IntelligentPlant.Models;
using System.ComponentModel;

namespace IntelligentPlant.ViewModels
{
    class MainViewsModels : INotifyPropertyChanged
    {
        private string currentImage;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string CurrentImage
        {
            get { return currentImage; }
            set { 
                currentImage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentImage"));
            }
        }

        public RelayCommand<object> NavCommand { get; set; }

#if fause
        public SwitchWorkShopCmd NavCommand { get; set; }
        public void CurrentImageChand(int a)
        {
            this.CurrentImage = DeviceGroups[a].Image;
        }
#endif

        //基本信息池
        public List<DeviceGroupItem> DeviceGroups { get; set; } = new List<DeviceGroupItem>();

        public List<DeviceItems> deviceList { get; set; } = new List<DeviceItems>();
        public List<DeviceItems> DeviceList
        {
            get { return deviceList; }
            set
            {
                deviceList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceList"));
            }
        }

        public List<AbnormalItems> AbnormalList { get; set; } = new List<AbnormalItems>();

        public MainViewsModels() {
            //有多少个设备组
            DeviceGroups.Add(new DeviceGroupItem() {
                Image = "C:\\CSharp_Study\\Array\\ProJect\\IntelligentPlant\\Resource\\Images\\deviceImage\\自动化车间设备1.png",
                //多少台设备
                devices = new List<DeviceItems>() {
                    new DeviceItems() {
                        Id = 1,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 2,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 3,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 4,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    }
                }
            });
            DeviceGroups.Add(new DeviceGroupItem()
            {
                Image = "C:\\CSharp_Study\\Array\\ProJect\\IntelligentPlant\\Resource\\Images\\deviceImage\\自动化车间设备13.png",
                //多少台设备
                devices = new List<DeviceItems>() {
                    new DeviceItems() {
                        Id = 5,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 6,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 7,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 8,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    }
                }
            });
            DeviceGroups.Add(new DeviceGroupItem()
            {
                Image = "C:\\CSharp_Study\\Array\\ProJect\\IntelligentPlant\\Resource\\Images\\deviceImage\\自动化车间设备3.png",
                //多少台设备
                devices = new List<DeviceItems>() {
                    new DeviceItems() {
                        Id = 9,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 10,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 11,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 12,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    }
                }
            });
            DeviceGroups.Add(new DeviceGroupItem()
            {
                Image = "C:\\CSharp_Study\\Array\\ProJect\\IntelligentPlant\\Resource\\Images\\deviceImage\\自动化车间设备7.png",
                //多少台设备
                devices = new List<DeviceItems>() {
                    new DeviceItems() {
                        Id = 13,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 14,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 15,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 16,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    }
                }
            });
            DeviceGroups.Add(new DeviceGroupItem()
            {
                Image = "C:\\CSharp_Study\\Array\\ProJect\\IntelligentPlant\\Resource\\Images\\deviceImage\\自动化车间设备15.png",
                //多少台设备
                devices = new List<DeviceItems>() {
                    new DeviceItems() {
                        Id = 17,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 18,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 19,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    },
                    new DeviceItems() {
                        Id = 20,
                        IsWarning = true,
                        Variables = new List<VariableItem>() {
                            new VariableItem() {
                                Name = "工作模式",
                                Value = "Auto"
                            },
                            new VariableItem() {
                                Name = "进给倍率",
                                Value = "0"
                            },
                            new VariableItem() {
                                Name = "主轴转速",
                                Value = "0",
                                Unit = "r/min"
                            },
                            new VariableItem() {
                                Name = "机床坐标-X",
                                Value = "-500.000",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Y",
                                Value = "-122.002",
                                Unit = "mm"
                            },
                            new VariableItem() {
                                Name = "机床坐标-Z",
                                Value = "-123.300",
                                Unit = "mm"
                            }
                        }
                    }
                }
            });

            for (int i = 0; i < 15; i++) {
                AbnormalList.Add(new Models.AbnormalItems() { Id = i + 1 });
            }

            //NavCommand = new SwitchWorkShopCmd(CurrentImageChand);
            NavCommand = new RelayCommand<object>(OnNav);

            OnNav(0);
        }

        private void OnNav(object? obj)
        {
            var group = DeviceGroups[int.Parse(obj.ToString())];
            CurrentImage = group.Image;

            DeviceList = group.devices;            
        }
    }
}
