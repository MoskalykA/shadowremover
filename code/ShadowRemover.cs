using Sandbox.Tools;

namespace Sandbox.MoskalykA
{
	[Library( "tool_shadowremover", Title = "Shadow remover", Description = "Left click: Invert shadow display state\nReload: Remove shadow", Group = "construction" )]
	public class ShadowRemover : BaseTool
	{
		public override void Simulate()
		{
			if ( !Game.IsServer )
				return;

			if (Input.Pressed( "attack1" )) {
				var tr = DoTrace();

				if ( !tr.Hit || !tr.Entity.IsValid() )
					return;

				var entity = tr.Entity.Root;
				if ( !entity.IsValid() )
					return;

				entity.EnableShadowCasting = !entity.EnableShadowCasting;
			} else if ( Input.Pressed( "reload" ) )
			{
				var tr = DoTrace();

				if ( !tr.Hit || !tr.Entity.IsValid() )
					return;

				var entity = tr.Entity.Root;
				if ( !entity.IsValid() )
					return;

				entity.EnableShadowCasting = false;
			}
		}
	}
}
