using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4.Discounts
{
    /// <summary>
    /// Использует фиксированное значение сертификата для уменьшения цены покупки.
    /// </summary>
    public sealed class CertificateDiscount : DiscountStrategy
    {
        /// <summary>
        /// Хранит значение скидки по сертефикату.
        /// </summary>
        private decimal _certificateValue;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CertificateDiscount"/>.
        /// </summary>
        /// <param name="certificateValue">Номинал сертификата.</param>
        public CertificateDiscount(decimal certificateValue)
        {
            CertificateValue = certificateValue;
        }

        /// <summary>
        /// Денежное значение сертификата. Должно быть положительным.
        /// </summary>
        public decimal CertificateValue
        {
            get => _certificateValue;
            set
            {
                if (value <= 0)
                {
                    throw new IncorrectArgumentException(nameof(value),
                        "Номинал сертификата должен быть положительным.");
                }

                _certificateValue = value;
            }
        }

        /// <inheritdoc />
        public override string Description =>
            $"Скидка по сертификату на сумму {CertificateValue:N2} руб.";

        /// <inheritdoc />
        public override decimal CalculateDiscount(decimal purchaseAmount)
        {
            ValidatePurchaseAmount(purchaseAmount);
            return Math.Min(purchaseAmount, CertificateValue);
        }
    }
}
