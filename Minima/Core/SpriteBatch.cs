using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace MinimaFramework
{
	public class SpriteBatch
	{
		private VertexArray _batch;
		private Texture _texture;


		public SpriteBatch()
		{
			_batch = new VertexArray(PrimitiveType.Quads);
		}

		public void AddSprite(Sprite drawable, Transformable t)
		{
			var rect = drawable.GetGlobalBounds();
			_texture = drawable.Texture;
			
			_batch.Append(new Vertex()
			{
				Position = t.Position,
				TexCoords = new Vector2f(),
				Color = Color.White
			});
			_batch.Append(new Vertex()
			{
				Position = new Vector2f(t.Position.X+rect.Width, t.Position.Y),
				TexCoords = new Vector2f(25,0),
				Color = Color.White
			});
			
			_batch.Append(new Vertex()
			{
				Position = new Vector2f(t.Position.X+rect.Width, t.Position.Y+rect.Height),
				TexCoords = new Vector2f(25, 50),
				Color = Color.White
			});	
			_batch.Append(new Vertex()
			{
				Position = t.Position,
				TexCoords = new Vector2f(t.Position.X,t.Position.Y+rect.Height),
				Color = Color.White
			});
		}

		public void Draw()
		{
			RenderStates states = new RenderStates()
			{
				BlendMode = BlendMode.None,
				Transform = Transform.Identity,
				Texture = _texture,
				Shader = null
			};
			
			_batch.Draw(Minima.GetInstance().Window, states);
			var s = new Sprite();
			s.TextureRect = new IntRect(0,0,10,10);
			s.Draw(Minima.GetInstance().Window, new RenderStates(){
				BlendMode = BlendMode.None, 
				Transform = Transform.Identity,
				Texture = _texture,
				Shader =  null
			});
			_batch.Clear();
		}

		
		
	}
}