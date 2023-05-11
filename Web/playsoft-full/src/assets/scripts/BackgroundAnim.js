import anime from "animejs";

export function anim(index) {
  var spans = document.querySelectorAll('.background-span')
  spans.forEach(span => {
    span.style.backgroundColor = '#0f0f0f'
  })
  anime({
    targets: ".background-span",
    scale: 0.98,
    backgroundColor: '#e994e6',
    duration: 10,
    delay: anime.stagger(10, { grid: [18, 9], from: index }),
    endDelay: 10,
    direction: 'alternate',
    easing: 'easeInQuad'
  })
}