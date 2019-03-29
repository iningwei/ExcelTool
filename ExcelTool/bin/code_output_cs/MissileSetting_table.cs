﻿using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class MissileSetting_table{
		private MissileSetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		/// <summary>
		/// 数量
		/// </summary>
		 public int Count{
			get{ return this.count;}
		}

		static MissileSetting_table instance=null;
		public static MissileSetting_table Instance{
			get{
				if(instance==null){
					instance=new MissileSetting_table();
					instance.Load();
				}
				return instance;
			}
		}

		void Load(){
			Action<string> onTableLoad=(text)=>{
				string[] lines=text.Split(new string[]{"\r\n"},System.StringSplitOptions.RemoveEmptyEntries);
				int count=lines.Length;
				if(count<0){
					return;
				}
				this.count = count;
				entities=new MissileSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new MissileSetting();
					entities[i].ID=int.Parse(vals[0].Trim());
					entities[i].Name=int.Parse(vals[1].Trim());
					entities[i].EquipmentType=int.Parse(vals[2].Trim());
					entities[i].Speed=float.Parse(vals[3].Trim());
					entities[i].Damage=float.Parse(vals[4].Trim());
					entities[i].Defence=float.Parse(vals[5].Trim());
					entities[i].CoinReward=float.Parse(vals[6].Trim());
					entities[i].CoinMultiply=float.Parse(vals[7].Trim());
					entities[i].BulletID=int.Parse(vals[8].Trim());
					entities[i].DefaultLv=int.Parse(vals[9].Trim());
					entities[i].MaxLv=int.Parse(vals[10].Trim());
					entities[i].UnlockType=int.Parse(vals[11].Trim());
					entities[i].UnlockValue=int.Parse(vals[12].Trim());
					entities[i].= vals[13].Trim();
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=MissileSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，对应excel数据中的对应行
		/// </summary>
		public MissileSetting GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// 根据主键获得具体某行数据
		/// 需要确保主键不重复
		/// </summary>
		public MissileSetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(MissileSetting);
			}
		}
	}
}