using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace SelfTable{
	public class BulletSettingReader{
		private BulletSetting[] entities;
		private Dictionary<string,int> keyIndexMap = new Dictionary<string,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static BulletSettingReader instance=null;
		public static BulletSettingReader Instance{
			get{
				if(instance==null){
					instance=new BulletSettingReader();
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
				entities=new BulletSetting[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new BulletSetting();
					entities[i].Name=vals[0];
					entities[i].MoveSpeed=float.Parse(vals[1].Trim());
					entities[i].HitType=int.Parse(vals[2].Trim());
					entities[i].Area=float.Parse(vals[3].Trim());
					entities[i].AutoDestroyType=int.Parse(vals[4].Trim());
					entities[i].LifeTime=float.Parse(vals[5].Trim());
					keyIndexMap[entities[i].Name]=i;
				}
			};

			string fileName=BulletSetting.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// 根据Index获得具体某行数据
		/// index从0开始，和excel数据表中的行对应
		/// </summary>
		public BulletSetting GetEntityByRowIndex(int index){
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
		public BulletSetting GetEntityByPrimaryKey(string key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(BulletSetting);
			}
		}
		/// <summary>
		/// 获得所有数据项
		/// </summary>
		public BulletSetting[] AllItems(){
			return this.entities;
		}
	}
}