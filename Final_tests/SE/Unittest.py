import unittest

def power(base, exp):
    if base == 0:
        raise ValueError("Base cannot be 0")
    return base ** exp

class TestPowerFunction(unittest.TestCase):

    def test_positive_exponent(self):
        self.assertEqual(power(2, 3), 8)  

    def test_negative_exponent(self):
        self.assertEqual(power(2, -3), 0.125)  

    def test_exponent_zero(self):
        self.assertEqual(power(7, 0), 1)  

    def test_base_non_zero_exponent_negative(self):
        self.assertEqual(power(5, -2), 0.04)

    def test_base_zero(self):
        with self.assertRaises(ValueError):
            power(0, 9)  # Base cannot be 0

    def test_base_zero_negative_exponent(self):
        with self.assertRaises(ValueError):
            power(0, -1)  # Base cannot be 0

if __name__ == '__main__':
    unittest.main()
