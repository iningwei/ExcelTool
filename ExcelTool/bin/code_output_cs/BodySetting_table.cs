using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class BodySetting_table{
		private BodySetting[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		/// <summary>
		/// 数量
		/// </summary>
		 public int Count{
			get{ return this.count;}
		}

		static BodySetting_table instance=null;
		public static BodySetting_table Instance{
			get{
				if(instance==null){
					instance=new BodySetting_table();
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
				entities=new BodySetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new BodySetting();
					entities[i].ID=vals[0]==null?0:int.Parse(vals[0].Trim());
					entities[i].Name=vals[1]==null?0:int.Parse(vals[1].Trim());
					entities[i].UnitType=vals[2]==null?0:int.Parse(vals[2].Trim());
					entities[i].Speed=vals[3]==null?0:float.Parse(vals[3].Trim());
					entities[i].Damage=vals[4]==null?0:float.Parse(vals[4].Trim());
					entities[i].Defence=vals[5]==null?0:float.Parse(vals[5].Trim());
					entities[i].CoinReward=vals[6]==null?0:float.Parse(vals[6].Trim());
					entities[i].CoinMultiply=vals[7]==null?0:float.Parse(vals[7].Trim());
					entities[i].BulletID=vals[8]==null?0:int.Parse(vals[8].Trim());
					entities[i].DefaultLv=vals[9]==null?0:int.Parse(vals[9].Trim());
					entities[i].MaxLv=vals[10]==null?0:int.Parse(vals[10].Trim());
					entities[i].UnlockType=vals[11]==null?0:int.Parse(vals[11].Trim());
					entities[i].UnlockValue=vals[12]==null?0:int.Parse(vals[12].Trim());
					entities[i].AtlasName=vals[13]==null?null:vals[13].Trim();
					entities[i].SpriteName=vals[14]==null?null:vals[14].Trim();
					entities[i].PropertyPlus=vals[15]==null?null:vals[15].Trim();
					keyIndexMap[entities[i].ID]=i;
				}
			};

			string fileName=BodySetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，对应excel数据中的对应行
		/// </summary>
		public BodySetting GetEntityByRowIndex(int index){
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
		public BodySetting GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(BodySetting);
			}
		}
		/// <summary>
		/// 获得所有数据项
		/// </summary>
		public BodySetting[] AllItems(){
			return this.entities;
		}
	}
}