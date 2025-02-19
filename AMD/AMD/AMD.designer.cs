﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMD
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AMDdb")]
	public partial class AMDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    #endregion
		
		public AMDDataContext() : 
				base(global::AMD.Properties.Settings.Default.AMDdbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AMDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AMDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AMDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AMDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Item> Items
		{
			get
			{
				return this.GetTable<Item>();
			}
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FullName;
		
		private string _Username;
		
		private string _Password;
		
		private string _Role;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="NVarChar(50)")]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(50)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="NVarChar(50)")]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Items")]
	public partial class Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _ItemName;
		
		private System.Nullable<System.DateTime> _DateArrived;
		
		private System.Nullable<int> _BaleQuantity;
		
		private System.Nullable<double> _BaleActualPrice;
		
		private System.Nullable<double> _BaleShopPrice;
		
		private System.Nullable<int> _PiecesPerBale;
		
		private System.Nullable<double> _PiecesActualPrice;
		
		private System.Nullable<double> _PiecesShopPrice;
		
		private string _ItemComment;
		
		private System.Nullable<int> _TotalPieces;
		
		private System.Nullable<double> _BaleActualPriceTotal;
		
		private System.Nullable<double> _BaleShopPriceTotal;
		
		private System.Nullable<double> _PiecesPerBaleTotal;
		
		private System.Nullable<double> _PiecesActualPriceTotal;
		
		private System.Nullable<double> _PiecesShopPriceTotal;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnItemNameChanging(string value);
    partial void OnItemNameChanged();
    partial void OnDateArrivedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateArrivedChanged();
    partial void OnBaleQuantityChanging(System.Nullable<int> value);
    partial void OnBaleQuantityChanged();
    partial void OnBaleActualPriceChanging(System.Nullable<double> value);
    partial void OnBaleActualPriceChanged();
    partial void OnBaleShopPriceChanging(System.Nullable<double> value);
    partial void OnBaleShopPriceChanged();
    partial void OnPiecesPerBaleChanging(System.Nullable<int> value);
    partial void OnPiecesPerBaleChanged();
    partial void OnPiecesActualPriceChanging(System.Nullable<double> value);
    partial void OnPiecesActualPriceChanged();
    partial void OnPiecesShopPriceChanging(System.Nullable<double> value);
    partial void OnPiecesShopPriceChanged();
    partial void OnItemCommentChanging(string value);
    partial void OnItemCommentChanged();
    partial void OnTotalPiecesChanging(System.Nullable<int> value);
    partial void OnTotalPiecesChanged();
    partial void OnBaleActualPriceTotalChanging(System.Nullable<double> value);
    partial void OnBaleActualPriceTotalChanged();
    partial void OnBaleShopPriceTotalChanging(System.Nullable<double> value);
    partial void OnBaleShopPriceTotalChanged();
    partial void OnPiecesPerBaleTotalChanging(System.Nullable<double> value);
    partial void OnPiecesPerBaleTotalChanged();
    partial void OnPiecesActualPriceTotalChanging(System.Nullable<double> value);
    partial void OnPiecesActualPriceTotalChanged();
    partial void OnPiecesShopPriceTotalChanging(System.Nullable<double> value);
    partial void OnPiecesShopPriceTotalChanged();
    #endregion
		
		public Item()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemName", DbType="NVarChar(50)")]
		public string ItemName
		{
			get
			{
				return this._ItemName;
			}
			set
			{
				if ((this._ItemName != value))
				{
					this.OnItemNameChanging(value);
					this.SendPropertyChanging();
					this._ItemName = value;
					this.SendPropertyChanged("ItemName");
					this.OnItemNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateArrived", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateArrived
		{
			get
			{
				return this._DateArrived;
			}
			set
			{
				if ((this._DateArrived != value))
				{
					this.OnDateArrivedChanging(value);
					this.SendPropertyChanging();
					this._DateArrived = value;
					this.SendPropertyChanged("DateArrived");
					this.OnDateArrivedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaleQuantity", DbType="Int")]
		public System.Nullable<int> BaleQuantity
		{
			get
			{
				return this._BaleQuantity;
			}
			set
			{
				if ((this._BaleQuantity != value))
				{
					this.OnBaleQuantityChanging(value);
					this.SendPropertyChanging();
					this._BaleQuantity = value;
					this.SendPropertyChanged("BaleQuantity");
					this.OnBaleQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaleActualPrice", DbType="Float")]
		public System.Nullable<double> BaleActualPrice
		{
			get
			{
				return this._BaleActualPrice;
			}
			set
			{
				if ((this._BaleActualPrice != value))
				{
					this.OnBaleActualPriceChanging(value);
					this.SendPropertyChanging();
					this._BaleActualPrice = value;
					this.SendPropertyChanged("BaleActualPrice");
					this.OnBaleActualPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaleShopPrice", DbType="Float")]
		public System.Nullable<double> BaleShopPrice
		{
			get
			{
				return this._BaleShopPrice;
			}
			set
			{
				if ((this._BaleShopPrice != value))
				{
					this.OnBaleShopPriceChanging(value);
					this.SendPropertyChanging();
					this._BaleShopPrice = value;
					this.SendPropertyChanged("BaleShopPrice");
					this.OnBaleShopPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesPerBale", DbType="Int")]
		public System.Nullable<int> PiecesPerBale
		{
			get
			{
				return this._PiecesPerBale;
			}
			set
			{
				if ((this._PiecesPerBale != value))
				{
					this.OnPiecesPerBaleChanging(value);
					this.SendPropertyChanging();
					this._PiecesPerBale = value;
					this.SendPropertyChanged("PiecesPerBale");
					this.OnPiecesPerBaleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesActualPrice", DbType="Float")]
		public System.Nullable<double> PiecesActualPrice
		{
			get
			{
				return this._PiecesActualPrice;
			}
			set
			{
				if ((this._PiecesActualPrice != value))
				{
					this.OnPiecesActualPriceChanging(value);
					this.SendPropertyChanging();
					this._PiecesActualPrice = value;
					this.SendPropertyChanged("PiecesActualPrice");
					this.OnPiecesActualPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesShopPrice", DbType="Float")]
		public System.Nullable<double> PiecesShopPrice
		{
			get
			{
				return this._PiecesShopPrice;
			}
			set
			{
				if ((this._PiecesShopPrice != value))
				{
					this.OnPiecesShopPriceChanging(value);
					this.SendPropertyChanging();
					this._PiecesShopPrice = value;
					this.SendPropertyChanged("PiecesShopPrice");
					this.OnPiecesShopPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemComment", DbType="NVarChar(100)")]
		public string ItemComment
		{
			get
			{
				return this._ItemComment;
			}
			set
			{
				if ((this._ItemComment != value))
				{
					this.OnItemCommentChanging(value);
					this.SendPropertyChanging();
					this._ItemComment = value;
					this.SendPropertyChanged("ItemComment");
					this.OnItemCommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalPieces", DbType="Int")]
		public System.Nullable<int> TotalPieces
		{
			get
			{
				return this._TotalPieces;
			}
			set
			{
				if ((this._TotalPieces != value))
				{
					this.OnTotalPiecesChanging(value);
					this.SendPropertyChanging();
					this._TotalPieces = value;
					this.SendPropertyChanged("TotalPieces");
					this.OnTotalPiecesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaleActualPriceTotal", DbType="Float")]
		public System.Nullable<double> BaleActualPriceTotal
		{
			get
			{
				return this._BaleActualPriceTotal;
			}
			set
			{
				if ((this._BaleActualPriceTotal != value))
				{
					this.OnBaleActualPriceTotalChanging(value);
					this.SendPropertyChanging();
					this._BaleActualPriceTotal = value;
					this.SendPropertyChanged("BaleActualPriceTotal");
					this.OnBaleActualPriceTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BaleShopPriceTotal", DbType="Float")]
		public System.Nullable<double> BaleShopPriceTotal
		{
			get
			{
				return this._BaleShopPriceTotal;
			}
			set
			{
				if ((this._BaleShopPriceTotal != value))
				{
					this.OnBaleShopPriceTotalChanging(value);
					this.SendPropertyChanging();
					this._BaleShopPriceTotal = value;
					this.SendPropertyChanged("BaleShopPriceTotal");
					this.OnBaleShopPriceTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesPerBaleTotal", DbType="Float")]
		public System.Nullable<double> PiecesPerBaleTotal
		{
			get
			{
				return this._PiecesPerBaleTotal;
			}
			set
			{
				if ((this._PiecesPerBaleTotal != value))
				{
					this.OnPiecesPerBaleTotalChanging(value);
					this.SendPropertyChanging();
					this._PiecesPerBaleTotal = value;
					this.SendPropertyChanged("PiecesPerBaleTotal");
					this.OnPiecesPerBaleTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesActualPriceTotal", DbType="Float")]
		public System.Nullable<double> PiecesActualPriceTotal
		{
			get
			{
				return this._PiecesActualPriceTotal;
			}
			set
			{
				if ((this._PiecesActualPriceTotal != value))
				{
					this.OnPiecesActualPriceTotalChanging(value);
					this.SendPropertyChanging();
					this._PiecesActualPriceTotal = value;
					this.SendPropertyChanged("PiecesActualPriceTotal");
					this.OnPiecesActualPriceTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PiecesShopPriceTotal", DbType="Float")]
		public System.Nullable<double> PiecesShopPriceTotal
		{
			get
			{
				return this._PiecesShopPriceTotal;
			}
			set
			{
				if ((this._PiecesShopPriceTotal != value))
				{
					this.OnPiecesShopPriceTotalChanging(value);
					this.SendPropertyChanging();
					this._PiecesShopPriceTotal = value;
					this.SendPropertyChanged("PiecesShopPriceTotal");
					this.OnPiecesShopPriceTotalChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CustomerName;
		
		private string _CustomerID;
		
		private System.Nullable<System.DateTime> _DateBought;
		
		private string _ItemName;
		
		private System.Nullable<double> _Price;
		
		private System.Nullable<int> _Quantity;
		
		private System.Nullable<int> _ItemsSold;
		
		private string _PaymentType;
		
		private string _Cash;
		
		private string _Transfer;
		
		private string _Bank;
		
		private System.Nullable<double> _SubTotal;
		
		private System.Nullable<double> _Total;
		
		private System.Nullable<double> _ReducedPrice;
		
		private string _Comment;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCustomerNameChanging(string value);
    partial void OnCustomerNameChanged();
    partial void OnCustomerIDChanging(string value);
    partial void OnCustomerIDChanged();
    partial void OnDateBoughtChanging(System.Nullable<System.DateTime> value);
    partial void OnDateBoughtChanged();
    partial void OnItemNameChanging(string value);
    partial void OnItemNameChanged();
    partial void OnPriceChanging(System.Nullable<double> value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(System.Nullable<int> value);
    partial void OnQuantityChanged();
    partial void OnItemsSoldChanging(System.Nullable<int> value);
    partial void OnItemsSoldChanged();
    partial void OnPaymentTypeChanging(string value);
    partial void OnPaymentTypeChanged();
    partial void OnCashChanging(string value);
    partial void OnCashChanged();
    partial void OnTransferChanging(string value);
    partial void OnTransferChanged();
    partial void OnBankChanging(string value);
    partial void OnBankChanged();
    partial void OnSubTotalChanging(System.Nullable<double> value);
    partial void OnSubTotalChanged();
    partial void OnTotalChanging(System.Nullable<double> value);
    partial void OnTotalChanged();
    partial void OnReducedPriceChanging(System.Nullable<double> value);
    partial void OnReducedPriceChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    #endregion
		
		public Customer()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerName", DbType="NVarChar(50)")]
		public string CustomerName
		{
			get
			{
				return this._CustomerName;
			}
			set
			{
				if ((this._CustomerName != value))
				{
					this.OnCustomerNameChanging(value);
					this.SendPropertyChanging();
					this._CustomerName = value;
					this.SendPropertyChanged("CustomerName");
					this.OnCustomerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="NVarChar(50)")]
		public string CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateBought", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateBought
		{
			get
			{
				return this._DateBought;
			}
			set
			{
				if ((this._DateBought != value))
				{
					this.OnDateBoughtChanging(value);
					this.SendPropertyChanging();
					this._DateBought = value;
					this.SendPropertyChanged("DateBought");
					this.OnDateBoughtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemName", DbType="NVarChar(50)")]
		public string ItemName
		{
			get
			{
				return this._ItemName;
			}
			set
			{
				if ((this._ItemName != value))
				{
					this.OnItemNameChanging(value);
					this.SendPropertyChanging();
					this._ItemName = value;
					this.SendPropertyChanged("ItemName");
					this.OnItemNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float")]
		public System.Nullable<double> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemsSold", DbType="Int")]
		public System.Nullable<int> ItemsSold
		{
			get
			{
				return this._ItemsSold;
			}
			set
			{
				if ((this._ItemsSold != value))
				{
					this.OnItemsSoldChanging(value);
					this.SendPropertyChanging();
					this._ItemsSold = value;
					this.SendPropertyChanged("ItemsSold");
					this.OnItemsSoldChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PaymentType", DbType="NVarChar(50)")]
		public string PaymentType
		{
			get
			{
				return this._PaymentType;
			}
			set
			{
				if ((this._PaymentType != value))
				{
					this.OnPaymentTypeChanging(value);
					this.SendPropertyChanging();
					this._PaymentType = value;
					this.SendPropertyChanged("PaymentType");
					this.OnPaymentTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cash", DbType="NVarChar(50)")]
		public string Cash
		{
			get
			{
				return this._Cash;
			}
			set
			{
				if ((this._Cash != value))
				{
					this.OnCashChanging(value);
					this.SendPropertyChanging();
					this._Cash = value;
					this.SendPropertyChanged("Cash");
					this.OnCashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Transfer", DbType="NVarChar(50)")]
		public string Transfer
		{
			get
			{
				return this._Transfer;
			}
			set
			{
				if ((this._Transfer != value))
				{
					this.OnTransferChanging(value);
					this.SendPropertyChanging();
					this._Transfer = value;
					this.SendPropertyChanged("Transfer");
					this.OnTransferChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bank", DbType="NVarChar(50)")]
		public string Bank
		{
			get
			{
				return this._Bank;
			}
			set
			{
				if ((this._Bank != value))
				{
					this.OnBankChanging(value);
					this.SendPropertyChanging();
					this._Bank = value;
					this.SendPropertyChanged("Bank");
					this.OnBankChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubTotal", DbType="Float")]
		public System.Nullable<double> SubTotal
		{
			get
			{
				return this._SubTotal;
			}
			set
			{
				if ((this._SubTotal != value))
				{
					this.OnSubTotalChanging(value);
					this.SendPropertyChanging();
					this._SubTotal = value;
					this.SendPropertyChanged("SubTotal");
					this.OnSubTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Total", DbType="Float")]
		public System.Nullable<double> Total
		{
			get
			{
				return this._Total;
			}
			set
			{
				if ((this._Total != value))
				{
					this.OnTotalChanging(value);
					this.SendPropertyChanging();
					this._Total = value;
					this.SendPropertyChanged("Total");
					this.OnTotalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReducedPrice", DbType="Float")]
		public System.Nullable<double> ReducedPrice
		{
			get
			{
				return this._ReducedPrice;
			}
			set
			{
				if ((this._ReducedPrice != value))
				{
					this.OnReducedPriceChanging(value);
					this.SendPropertyChanging();
					this._ReducedPrice = value;
					this.SendPropertyChanged("ReducedPrice");
					this.OnReducedPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="NVarChar(50)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
