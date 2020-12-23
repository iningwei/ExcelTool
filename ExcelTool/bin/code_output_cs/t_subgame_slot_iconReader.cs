using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;

namespace ZGame.ZTable{
	public class t_subgame_slot_iconReader{
		private t_subgame_slot_icon[] entities;
		private Dictionary<int,int> keyIndexMap = new Dictionary<int,int>();

		private int count;
		 public int Count{
			get{ return this.count;}
		}

		static t_subgame_slot_iconReader instance=null;
		public static t_subgame_slot_iconReader Instance{
			get{
				if(instance==null){
					instance=new t_subgame_slot_iconReader();
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
				entities=new t_subgame_slot_icon[count];
				for(int i=0;i<count;i++){
					string line=lines[i];
					if(string.IsNullOrEmpty(line)){
						Debug.LogError("data error, line "+i+" is null");
					}
					string[] vals=line.Split('\t');
					entities[i]=new t_subgame_slot_icon();
					entities[i].t_id=int.Parse(vals[0].Trim());
					entities[i].subgame_id=int.Parse(vals[1].Trim());
					entities[i].icon_id=int.Parse(vals[2].Trim());
					entities[i].package_name=vals[3];
					entities[i].res_name=vals[4];
					entities[i].effect_id=int.Parse(vals[5].Trim());
					entities[i].des=vals[6];
					keyIndexMap[entities[i].t_id]=i;
				}
			};

			string fileName=t_subgame_slot_icon.FileName;
			FileMgr.ReadFile(fileName,onTableLoad);
		}

		/// <summary>
		/// get datas of a row by Index
		/// index starts form 0,which marching the line 7 of excel table
		/// </summary>
		public t_subgame_slot_icon GetEntityByRowIndex(int index){
			if(index<0||index>count){
				Debug.LogError("index:"+index+" is not valid");
				return null;
			}
			else{
				return entities[index];
			}
		}
		/// <summary>
		/// get datas of a row by primary key
		/// </summary>
		public t_subgame_slot_icon GetEntityByPrimaryKey(int key){
			int index;
			if(keyIndexMap.TryGetValue(key,out index)){
				return entities[index];
			}
			else{
				Debug.LogError("no entity with key:"+key);
				return default(t_subgame_slot_icon);
			}
		}
		/// <summary>
		/// get all row datas
		/// </summary>
		public t_subgame_slot_icon[] AllItems(){
			return this.entities;
		}
	}
}