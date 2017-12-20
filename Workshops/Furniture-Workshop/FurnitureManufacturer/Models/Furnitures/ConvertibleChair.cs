using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = this.Height;
        }

        public bool IsConverted => this.isConverted;

        public void Convert()
        {
            this.isConverted = this.isConverted == false ? this.isConverted == true : this.isConverted = false;

            if (isConverted)
            {
                this.Height = 0.10m;
            }
            else
            {
                this.Height = initialHeight;
            }
        }

        public override string AdditionalInfo()
        {
            string normalOrConverted = this.isConverted == true ? "Converted" : "Normal";
            return base.AdditionalInfo() + $" State: {normalOrConverted}";
        }
    }
}
